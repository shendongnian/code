    public static MyEnum? ParseEnum(string input)
    {
        int value;
        var isInt = int.TryParse(input, out value);
        return (MyEnum?) Enum.GetValues(typeof(MyEnum)).OfType<object>()
                             .FirstOrDefault(v => v.ToString() == input
                                               || (isInt & (int)v == value));
    }
