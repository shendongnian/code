    protected void override OnModelCreating(ModelBuilder builder)
    {
       var colorTable = builder.Entity<ColorData>();
       colorTable.HasKey(x => x.Id).HasColumnName("COLOR_ID");
       colorTable.Property(x => x.Argb).HasColumnName("COLOR_ARGB");
       colorTable.Ignore(x=>x.Color);
    
       colorTable.ToTable("COLOR_DATA");
    }
