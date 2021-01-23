    public T Deserialize<T>(string resp) where T : new()
    {
        var nameValuePairs = HttpUtility.ParseQueryString(resp);
        var obj = new T();
        var props = obj.GetType().GetProperties()
                       .ToDictionary(p => p.Name.Replace("_","") , p => p, StringComparer.InvariantCultureIgnoreCase);
        foreach(var key in nameValuePairs.AllKeys)
        {
            var newkey = key.Replace("_", "");
            if (props.ContainsKey(newkey))
                props[newkey].SetValue(obj, Convert.ChangeType(nameValuePairs[key], props[newkey].PropertyType));
        }
        return obj;
    }
