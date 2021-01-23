    /// <summary>
    /// Converts the value to a String
    /// </summary>
    public static implicit operator string(RedisValue value)
    {
        var valueBlob = value.valueBlob;
        if (valueBlob == IntegerSentinel)
            return Format.ToString(value.valueInt64);
        if (valueBlob == null) return null;
        
        if (valueBlob.Length == 0) return "";
        try
        {
            return Encoding.UTF8.GetString(valueBlob);
        }
        catch
        {
            return BitConverter.ToString(valueBlob);
        }
    }
