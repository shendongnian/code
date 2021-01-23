    Dictionary<string, Func<MyClass, string>> propertyGetters = 
        new Dictionary<string, Func<MyClass, string>>
        {
            { "CutoutKind", x => x.CutoutKind.ToString() }
            { "EdgeKind", x => x.EdgeKind.ToString() }
            { "EdgeKind", x => x.MaterialKind.ToString() }
        };
    static string SomeFunction(string format, MyClass instance)
    {
        return Regex.Replace(@"\{(\w+)\}", 
            m => propertyGetters.HasKey(m.Groups[1].Value) 
                     ? propertyGetters[m.Groups[1].Value](instance) 
                     : m.Value;
    }
