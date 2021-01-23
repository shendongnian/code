     modelBuilder.Entity<Box>(boxBuilder =>
            {
              boxBuilder.HasOne(box => box.Freezer)
                  .WithMany(freezer => freezer.Boxes)
                  .HasForeignKey(box => box.FreezerId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
    
              boxBuilder.HasMany(box => box.Comments)
                  .WithOne(comment => comment.Box)
                  .HasForeignKey(comment => comment.BoxId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
    
            modelBuilder.Entity<Freezer>(freezerBuilder =>
            {
              freezerBuilder.HasMany(freezer => freezer.Comments)
                  .WithOne(comment => comment.Freezer)
                  .HasForeignKey(comment => comment.FreezerId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);
          }
