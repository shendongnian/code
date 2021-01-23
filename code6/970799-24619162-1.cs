    public static string UpdateQueryParam(this UrlHelper helper, string param, object value)
    {
        return ModifyQueryString(helper, new NameValueCollection { { param, value.ToString() } }, null);
    }
    public static string UpdateQueryParam(this UrlHelper helper, string url, string param, object value)
    {
        return ModifyQueryString(helper, url, new NameValueCollection { { param, value.ToString() } }, null);
    }
