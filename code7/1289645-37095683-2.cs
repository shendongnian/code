    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property<int>("CreatedById");
        modelBuilder.Entity<User>().Property<DateTime>("Created");
        modelBuilder.Entity<User>().Property<int>("ModifiedById");
        modelBuilder.Entity<User>().Property<DateTime>("Modified");
    }
