    modelBuilder.Entity("myNamespace.Models.ChangeOrder", b =>
        {
            b.HasOne("myNamespace.Models.User")
                .WithMany()
                .HasForeignKey("CreatedByID")
                .OnDelete(DeleteBehavior.Cascade);
        });
