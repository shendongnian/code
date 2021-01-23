    public PricingIncrementMap()
        : base("PricingIncrement")
    {
        Map(x => x.IncrementYear);
        HasMany<OptionPrice>(x => x.OptionPrices)
            .KeyColumn("OptionIdentifier_id")
            .Cascade.None()
            .Inverse() // I would use .Inverse() as well
            // batch fetching
            .BatchSize(100);
    }
