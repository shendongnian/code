    static TEnum RandomEnumValue<TEnum>(Random rng)
    {
        var vals = Enum
            .GetNames(typeof(TEnum))
            .Aggregate(Enumerable.Empty<TEnum>(), (agg, curr) =>
            {
                var value = Enum.Parse(typeof(TEnum), curr);
                FieldInfo fi = typeof (TEnum).GetField(curr);
                var weight = ((PAttribute)fi.GetCustomAttribute(typeof(PAttribute), false)).Weight;
                return agg.Concat(Enumerable.Repeat((TEnum)value, weight)); // For int enums
            })
            .ToArray();
        return vals[rng.Next(vals.Length)];
    }
