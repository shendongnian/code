    public static string Serialize(object obj)
    {
        var sb = new StringBuilder();
        foreach (var p in obj.GetType().GetProperties())
        {
            // default key name is the lowercase property name
            var key = p.Name.ToLowerInvariant();
            // we need to UrlEncode all values passed to an url
            var value = Uri.EscapeDataString(p.GetValue(obj, null).ToString());
            // if custom attribute is specified, use that value instead
            var attr = p
                .GetCustomAttributes(typeof(MyApiNameAttribute), false)
                .FirstOrDefault() as MyApiNameAttribute;
            if (attr != null)
                key = attr.Name;
                
            sb.AppendFormat(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0}={1}&",
                key, value);
        }
        // trim trailing ampersand
        if (sb.Length > 0 && sb[sb.Length - 1] == '&')
            sb.Length--;
        return sb.ToString();
    }
