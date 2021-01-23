    foreach (PropertyInfo property in properties)
    {
        var ca = property.GetCustomAttributes(false);
    
        foreach (var attribute in ca)
        {
            if (attribute is YourAttribute)
            {
                            //...
            }
         }
    }
