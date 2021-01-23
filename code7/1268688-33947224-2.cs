    internal static MyEnum[] GetFlags(this MyEnum modKey)
    {
        List<MyEnum> flags = new List<MyEnum>();
        foreach (var flag in Enum.GetValues(typeof(MyEnum)))
        {
            if (modKey & flag == flag)
                flags.Add((MyEnum)flag);
        }
        return flags.ToArray(); 
    }
