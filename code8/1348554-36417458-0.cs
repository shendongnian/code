    foreach (var property in properties)
    {
        if (typeof(List<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
        {
            //codes here
    
        }
    }
