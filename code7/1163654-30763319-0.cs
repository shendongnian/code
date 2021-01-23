    PropertyInfo prop =
        typeof(Foo).GetProperty("FooBar", BindingFlags.NonPublic | BindingFlags.Instance);
        
    MethodInfo getter = prop.GetGetMethod(nonPublic: true);
    object bar = getter.Invoke(f, null);
