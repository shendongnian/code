    public static MyEnum? ParseEnum(string input)
    {
        int value;
        var isInt = int.TryParse(input, out value);
        return (MyEnum?) Enum.GetValues(typeof(MyEnum)).OfType<object>
                             .FirstOrDefauflt(v => v.ToString() == input
                                               || (isInt & (int)v == value));
    }
