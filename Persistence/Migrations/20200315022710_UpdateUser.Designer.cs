﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    [Migration("20200315022710_UpdateUser")]
    partial class UpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("PostId");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Education", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Current");

                    b.Property<string>("Degree");

                    b.Property<string>("Description");

                    b.Property<string>("FieldOfStudy");

                    b.Property<DateTime>("From");

                    b.Property<string>("School");

                    b.Property<DateTime>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Domain.Experience", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<bool>("Current");

                    b.Property<string>("Description");

                    b.Property<DateTime>("From");

                    b.Property<string>("Location");

                    b.Property<string>("Title");

                    b.Property<DateTime>("To");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Domain.Like", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("PostId");

                    b.Property<DateTime>("Date");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("PhotoId");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.Property<string>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId")
                        .IsUnique();

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Domain.Profile", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("AvatarId");

                    b.Property<string>("Bio");

                    b.Property<string>("Company");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Facebook");

                    b.Property<string>("GithubUsername");

                    b.Property<string>("Instagram");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Location");

                    b.Property<string>("Status");

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.HasKey("UserId");

                    b.HasIndex("AvatarId")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.Property<string>("UserProfileUserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserProfileUserId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Video", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Domain.Profile", "UserProfile")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Education", b =>
                {
                    b.HasOne("Domain.Profile")
                        .WithMany("Educations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Experience", b =>
                {
                    b.HasOne("Domain.Profile")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Like", b =>
                {
                    b.HasOne("Domain.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Profile", "UserProfile")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.HasOne("Domain.Photo", "Photo")
                        .WithOne()
                        .HasForeignKey("Domain.Post", "PhotoId");

                    b.HasOne("Domain.Profile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.Video", "Video")
                        .WithOne()
                        .HasForeignKey("Domain.Post", "VideoId");
                });

            modelBuilder.Entity("Domain.Profile", b =>
                {
                    b.HasOne("Domain.Photo", "Avatar")
                        .WithOne()
                        .HasForeignKey("Domain.Profile", "AvatarId");

                    b.HasOne("Domain.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Domain.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.HasOne("Domain.Profile")
                        .WithMany("Skills")
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.Profile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
