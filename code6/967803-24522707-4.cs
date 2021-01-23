    public static IEnumerable<Tuple<string, Func<object, object>>> FieldsOf(string className)
    {
        var asm = Assembly.GetCallingAssembly();
        var type = asm.GetTypes().Single(t => t.Name == className);
        var fields = type.GetFields();
    
        return fields.Select(f => Tuple.Create<string, Func<object, object>>(f.Name, f.GetValue));
    }
