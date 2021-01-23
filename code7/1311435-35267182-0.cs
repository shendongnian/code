    protected override object GetElementKey(ConfigurationElement element)
    {
        object key = element.GetType()
                            .GetProperties()
                            .Where(p => p.GetCustomAttributes<ConfigurationPropertyAttribute>()
                                         .Any(a => a.IsKey))
                            .Select(p => p.GetValue(element))
                            .FirstOrDefault();
        return key;
    }
