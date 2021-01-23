    public static string GetValue(RegistryKey key, string value)
    {
    string valueStr=(string)key.GetValue(value);
    return string.IsNullOrWhiteSpace(valueStr)?null:valueStr.ToLower();
    }
