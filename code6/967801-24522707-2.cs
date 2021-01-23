    public static IEnumerable<string> FieldsOf(string className)
    {
        var asm = Assembly.GetCallingAssembly();
        var type = asm.GetTypes().Single(t => t.Name == className);
        var fields = type.GetFields();
        return fields.Select(f => f.Name);
    }
