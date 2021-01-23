    internal static MyEnum[] GetFlags(this MyEnum modKey)
    {
        List<MyEnum> result = new List<MyEnum>();
        while (modKey != 0)
        {
            var highestFlag = Enum.GetValues(typeof(MyEnum))
                .Cast<MyEnum>()
                .OrderByDescending(v => v)
                .FirstOrDefault(v => modKey.HasFlag(v));
            result.Add(highestFlag);
            modKey ^= highestFlag;
        }
        return result.ToArray();
    }
