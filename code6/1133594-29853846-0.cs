    public static string GetValue(RegistryKey key, string value)
    {
        object valueObj = key.GetValue(value);
        if (valueObj == null)
            return null;
        string newValue = valueObj.ToString()
        if (String.IsNullOrWhiteSpace(newValue))
            return null;
        return newValue.ToLower();
    }
