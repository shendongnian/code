    protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                
                builder.Entity<DataSensor>()
                    .HasMany(p => p.Data)
                    .WithOne();
            }
            public DbSet<DataSensor> DataSensor { get; set; }
            public DbSet<GatheredData> GatheredData { get; set; }
