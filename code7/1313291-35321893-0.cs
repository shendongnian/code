    public Dictionary<String, String> GetPropertyValues<T>(T obj)
    {
        Dictionary<String, String> result = new Dictionary<String, String>();
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            String name = property.Name;
            String value = property.GetValue(obj).ToString();
            result.Add(name, value);
        }
        return result;
    }
