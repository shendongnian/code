    public static string ToBase64(this string value)
    {
        byte[] bytes = Encoding.Default.GetBytes(value);
        return Convert.ToBase64String(bytes);
    }
    public static string FromBase64(this string value)
    {
        byte[] bytes = Convert.FromBase64String(value);
        return Encoding.Default.GetString(bytes);
    }
