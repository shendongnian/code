    public static MyEnum? ParseEnum(string input)
    {
        return (MyEnum?) Enum.GetValues(typeof(MyEnum)).OfType<object>()
                             .FirstOrDefault(v => v.ToString() == input);
    }
