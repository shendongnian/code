    public object this[string key]
    {
        get
        {
            var property = typeof(YourClass).GetProperty(key);
            return property.GetValue(this);
        }
    }
