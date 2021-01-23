    var attrs = System.Attribute.GetCustomAttributes(typeof(MahClass));
    foreach (var attr in attrs)
    {
        if (attr is RegistryKey)
        {
            var name = attr.Name;
            ...
        }
    }
