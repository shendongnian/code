    private static void DeleteProperty(CustomProperties properties, string propertyName)
    {
        foreach(CustomProperty property in properties)
        {
            if (string.Equals(property.Name, propertyName, StringComparison.InvariantCultureIgnoreCase))
            {
                property.Remove();
                break;
            }
        }
    }
    private static void UpdateProperty(CustomProperties properties, string propertyName, string newValue)
    {
        bool propertyFound = false;
        
        foreach (CustomProperty property in properties)
        {
            if (string.Equals(property.Name, propertyName, StringComparison.InvariantCultureIgnoreCase))
            {
                // Property found, change it
                property.set_Value(newValue);
                propertyFound = true;
                break;
            }
        }
        if(!propertyFound)
        {
            // The property with the given name was not found, so we have to add it 
            properties.Add(propertyName, newValue);
        }
    }
