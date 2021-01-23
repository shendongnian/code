    static int RandomEnumValue<TEnum>()
    {
        var rng = new Random();
        var vals = Enum
            .GetValues(typeof(TEnum))
            .Cast<int>()
            .Aggregate(Enumerable.Empty<int>(),(curr,next) => curr.Concat(Enumerable.Repeat(next,next)))
            .ToArray();
        return vals[rng.Next(vals.Length)];
    }
