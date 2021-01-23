    public static Parser<TEnum> ParseEnum()
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(value => Parse.IgnoreCase(Enum.GetName(typeof(TEnum), value)).Return(value))
            .Aggregate((x, y) => x.Or(y));
    }
