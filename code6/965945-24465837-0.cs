    List<string> emptyProperties = typeof(MyType).GetProperties()
        .Select(prop => new { Prop = prop, Val = prop.GetValue(obj, null) } )
        .Where(val => IsEmpty((dynamic)val.Val) // <<== The "magic" is here
        .Select(val => val.Prop.Name)
        .ToList();
