    PropertyInfo strProperty = 
        bar.GetType().GetProperty("Str", BindingFlags.NonPublic | BindingFlags.Instance);
    
    MethodInfo strGetter = strProperty.GetGetMethod(nonPublic: true);
    
    string val = (string)strGetter.Invoke(bar, null);
