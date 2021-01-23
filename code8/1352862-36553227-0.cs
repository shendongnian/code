    public static MyEnum? ParseEnum(string input)
    {
        return (MyEnum?) Enum.GetValues(typeof(MyEnum))
                     .FirstOrDefauflt(v => v.ToString("G") == input);
    }
