    foreach (Type t in typeof(MyAssembly).Assembly.GetTypes())
    {
        PropertyInfo p = t.GetProperty("XYZ");
        if (p != null)
        { ... }
    }
