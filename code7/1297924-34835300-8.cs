    private static readonly ReadOnlyDictionary<int, string> _numberSuffix = new ReadOnlyDictionary<int, string>(new Dictionary<int, string> {
            { 0, String.Empty }, // default
            { 1, "K" }, // thousand
            { 2, "M" }, // million
            { 3, "B" }, // billion
            { 4, "T" }, // trillion
        });
