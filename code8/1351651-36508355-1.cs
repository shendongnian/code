    builder.Entity<UserSettings>()
                .Property(b => b.UserId)
                .HasColumnName("User_Id_Fk");
    builder.Entity<User>()
                .HasOne(us => us.UserSettings)
                .WithOne(u => u.User)
                .HasForeignKey<UserSettings>(b => b.UserId);
