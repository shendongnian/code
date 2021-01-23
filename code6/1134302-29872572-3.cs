    static TEnum RandomEnumValue<TEnum>(Random rng)
    {
        var vals = Enum
            .GetNames(typeof(TEnum))
            .Aggregate(Enumerable.Empty<TEnum>(), (agg, curr) =>
            {
                var value = Enum.Parse(typeof (TEnum), curr);
                return agg.Concat(Enumerable.Repeat((TEnum)value,(int)value)); // For int enums
            })
            .ToArray();
        return vals[rng.Next(vals.Length)];
    }
