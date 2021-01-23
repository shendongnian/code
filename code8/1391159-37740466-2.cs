    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasRequired(u => u.Shop).WithMany();
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(255).AddMultiColumnIndex("UX_User_EmailShopId", 0, unique: true);
        modelBuilder.Entity<User>().Property(x => x.ShopId).AddMultiColumnIndex("UX_User_EmailShopId", 1, unique: true);
    }
