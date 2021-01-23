    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var user = modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id).ToTable("User", "Users"); //Specify our our own table names instead of the defaults
        user.Property(iu => iu.Id).HasColumnName("Id");
        user.Property(iu => iu.UserName).HasColumnName("UserName");
        user.Property(iu => iu.Email).HasColumnName("EmailAddress").HasMaxLength(254).IsRequired();
        user.Property(iu => iu.IsConfirmed).HasColumnName("EmailConfirmed");
        user.Property(iu => iu.PasswordHash).HasColumnName("PasswordHash");
        user.Property(iu => iu.SecurityStamp).HasColumnName("SecurityStamp");
        user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
        user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
        user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
        user.Property(u => u.UserName).IsRequired();
    ...
