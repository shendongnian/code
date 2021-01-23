    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Add your customizations after calling base.OnModelCreating(builder);
        CustomDataTypeAttributeConvention.Apply(builder);
        DecimalPrecisionAttributeConvention.Apply(builder);
        SqlDefaultValueAttributeConvention.Apply(builder);
    }
