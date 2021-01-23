    internal static MyEnum[] GetFlags(this MyEnum modKey)
    {
        List<MyEnum> flags = new List<MyEnum>
        foreach (val flag in Enum.GetValues(typeof(MyEnum))
        {
            if (flag && modKey != 0)
                flags.Add(flag);
        }
        return flags.ToArray(); 
    }
