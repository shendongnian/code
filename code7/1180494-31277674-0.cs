    public Dictionary<string, object> MapToDictionary(object instance)
    {
        if(instance == null) return null;
        return instance.GetType()
                       .GetProperties()
                       .ToDictionary(p => p.Name, 
                                     p => p.GetValue(instance);
    }
