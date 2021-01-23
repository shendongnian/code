    MeritFunction<CalculationOutput> mf = new MeritFunction<CalculationOutput>
    {
        { x => x.Property1, ComparisonTypes.GreaterThan, 90 },
        { x => x.Property3, ComparisonTypes.Equals,      50 }
    };
