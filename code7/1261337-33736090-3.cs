    public static PropertyInfo GetPropertyInfoV2<TProp>(Expression<Func<TProp>> expressie)
    { ... }
    
    // call:
    var test = new SomeType();
    GetPropertyInfoV2(() => test.MyInspectedProperty);
