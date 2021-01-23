    classProps
    .GetType()
    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
    .Where(x => !x.PropertyType.IsClass)
    .ToDictionary(prop => prop.Name, prop => prop.GetValue(classProps, null));  
