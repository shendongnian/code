    public static IEnumerable<Tuple<string, Func<object, object>>> FieldsOf(Type type)
    {
        var fields = type.GetFields();
        var properties = type.GetProperties();
    
        return
            fields.Select(f => Tuple.Create<string, Func<object, object>>(f.Name, f.GetValue))
            .Concat(properties.Select(p => Tuple.Create<string, Func<object, object>>(p.Name, o => p.GetValue(o, null))));
    }
