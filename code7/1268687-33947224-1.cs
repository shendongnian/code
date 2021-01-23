    internal static MyEnum[] GetFlags(this MyEnum modKey)
    {
        List<MyEnum> flags = new List<MyEnum>
        foreach (val flag in Enum.GetValues(typeof(MyEnum))
        {
            if (modKey & flag == flag)
                flags.Add(flag);
        }
        return flags.ToArray(); 
    }
