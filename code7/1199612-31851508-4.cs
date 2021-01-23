    class Thing
    {
        private static int sharedCount = 0;
        private static readonly IDictionary<string, int> ThingLookup =
                new Dictionary<string, int>
                        {
                            { "a", 1 },
                            { "b", 2 }
                        };
    }
