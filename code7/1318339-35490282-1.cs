    static Expression<Func<IGrouping<int, ItemResponse>, TestClass>> ToTestClass()
    {
        return values => new TestClass
        {
            ItemID = values.Key,
            Average = values.Average(g => g.OptionValue)
            // ...etc. lots of properties
        };
    }
