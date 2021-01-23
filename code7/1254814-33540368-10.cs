    public IDbSet<Driver> Drivers { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDriver>().Ignore(x => x.Car);
        modelBuilder.Entity<TruckDriver>().Ignore(x => x.Truck);
        base.OnModelCreating(modelBuilder);
    }
