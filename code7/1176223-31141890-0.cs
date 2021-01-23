    public void AddToDictionary(Type key, object value)
    {
        if(!key.IsAssignableFrom(typeof(SomeBaseClass))
            throw new ArgumentException("Must be an inherited from SomeBaseClass type");
        dictionary.Add(key, value);
    }
