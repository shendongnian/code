    public static MyEnum? ParseEnum(string input)
    {
        int value;
        var isInt = int.TryParse(input, out value);
        return (MyEnum?) Enum.GetValues(typeof(MyEnum))
                     .FirstOrDefauflt(v => v.ToString("G") == input
                                         || (isInt & (int)v == value));
    }
