    var propertyNames = new[] { "Mushrooms", "Olives", "Zucchini", "Pepperoni" };
    var query = propertyNames
        .Select(n => types.GetType().GetProperty(n))
        .Where(p => p != null)
        .Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null && p.CanRead)
        .Select(p => new Row { c = new List<C> { new C { v = p.Name }, new C { v = p.GetValue(types, new object[0]) } } });
