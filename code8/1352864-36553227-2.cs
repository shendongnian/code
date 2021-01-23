    public static MyEnum? ParseEnum(string input)
    {
        return (MyEnum?) Enum.GetValues(typeof(MyEnum)).OfType<object>
                             .FirstOrDefauflt(v => v.ToString() == input);
    }
