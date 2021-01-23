    public TestClass(IGrouping<int, ItemResponse> values)
    {
        ItemID = values.Key;
        Average = values.Average(g => g.OptionValue);
        // ...etc. lots of properties
    } 
