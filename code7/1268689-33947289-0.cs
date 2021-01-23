    internal static MyEnum[] GetFlags(this MyEnum modKey)
    {
        return Enum.GetValues(typeof(MyEnum))
            .Cast<MyEnum>()
            .Where(v => modKey.HasFlag(v))
            .ToArray();
    }
