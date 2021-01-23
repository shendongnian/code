    var method = typeof(YourClassName).GetMethod("Show");
    foreach (var pi in method.GetParameters())
    {
        var optionalAttribute = pi.GetCustomAttributes<OptionalAttribute>().FirstOrDefault();
        if (optionalAttribute != null)
        {
            //This is optional parameter
            object defaultValue = pi.DefaultValue;
        }
    }
