    public static string GetValue(RegistryKey key, string name)
    {
        string value = key.GetValue(name)?.ToString();
        if (String.IsNullOrWhiteSpace(value))
            return null;
        return value.ToLower();
    }
