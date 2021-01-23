    public static string GetValue(RegistryKey key, string name)
    {
        object value = key.GetValue(name);
        if (value == null)
            return null;
        string valueStr = value.ToString()
        if (String.IsNullOrWhiteSpace(valueStr))
            return null;
        return valueStr.ToLower();
    }
