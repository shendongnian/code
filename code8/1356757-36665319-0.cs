    /// <summary>
    ///     Gets all public properties of an object and and puts them into dictionary.
    /// </summary>
    public static IDictionary<string, object> ToDictionary(this object instance)
    {
        if (instance == null)
            throw new NullReferenceException();
        // if an object is dynamic it will convert to IDictionary<string, object>
        var result = instance as IDictionary<string, object>;
        if (result != null)
            return result;
            
        return instance.GetType()
            .GetProperties()
            .ToDictionary(x => x.Name, x => x.GetValue(instance));
    }
