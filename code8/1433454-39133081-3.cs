    var ignoredPropertyNames = new HashSet<string> { "Statistics", "Average", "Count" };
    var query = types.GetType()
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null && p.CanRead)
        .Where(p => !ignoredPropertyNames.Contains(p.Name))
        .Select(p => new Row { c = new List<C> { new C { v = p.Name }, new C { v = p.GetValue(types, new object[0]) } } });
