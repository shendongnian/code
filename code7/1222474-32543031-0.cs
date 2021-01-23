        Dictionary<string, int> mapping = new Dictionary<string, int>()
        {
            { "Rcs Enabled", 0 },
            { "Rcs Start After", 1 },
            { "Rcs Force Max", 2 },
            { "Rcs Force Min", 3 }
            …
        };
    You can then use that mapping in the `OrderBy`:
        keys.OrderBy(k => mapping[k]);
