    PropertyInfo barGetter =
        typeof(Foo).GetProperty("FooBar", BindingFlags.NonPublic | BindingFlags.Instance)
    object bar = barGetter.GetValue(f);
    PropertyInfo strGetter =
        bar.GetType().GetProperty("Str", BindingFlags.NonPublic | BindingFlags.Instance);
    string val = (string)strGetter.GetValue(bar);
