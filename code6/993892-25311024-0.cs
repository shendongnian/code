    public static string ToBase64UrlString(string text)
    {
        return Convert.ToBase64String(text)
            .Replace('+', '-').Replace('/', '_');
    }
    public static string FromBase64UrlString(string text)
    {
        return Convert.FromBase64String(
            text.Replace('-', '+').Replace('_', '/'))
    }
