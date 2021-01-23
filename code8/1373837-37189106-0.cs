    // 1st level properties
    var parentProperties = obj.GetType().GetProperties();
    foreach (var prop in parentProperties)
    {
        // get the actual instance of this property
        var propertyInstance = prop.GetValue(obj, null);
        // get 2nd level properties
        var mainObjectsProperties = prop.PropertyType.GetProperties();
        foreach (var property in mainObjectsProperties)
        {
            // get the actual instance of this 2nd level property
            var leafInstance = property.GetValue(propertyInstance, null);
            // 3rd level props
            var leafProperties = property.PropertyType.GetProperties();
            foreach (var leafProperty in leafProperties)
            {
                Console.WriteLine("{0}={1}",
                    leafProperty.Name, leafProperty.GetValue(leafInstance, null));
            }
        }
    }
