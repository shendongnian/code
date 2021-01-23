    public static string AsQueryString(this IEnumerable<KeyValuePair<string, object>> parameters)
    {
        if (!parameters.Any())
            return "";
        var builder = new StringBuilder("?");
        var separator = "";
        foreach (var kvp in parameters.Where(kvp => kvp.Value != null))
        {
            builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));
            
            separator = "&";
        }
        return builder.ToString();
    }
