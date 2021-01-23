    foreach (var property in properties)
    {
        if (property.PropertyType.IsGenericType && 
            typeof(List<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
        {
            //codes here
    
        }
    }
