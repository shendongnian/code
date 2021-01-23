    var o = new DemoClass();
    var properties = o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
    var propertiesWithAttributes = 
        properties.Select(property => 
            new
            {
                Property = property,
                Attribute = property.GetCustomAttributes<TestAttribute>().FirstOrDefault()
            });
    var sorted =
        propertiesWithAttributes
        .OrderBy(pwa => pwa.Attribute != null ? pwa.Attribute.order : int.MaxValue);
