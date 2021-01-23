    public static string BuildApiCall(object obj)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("http://mytestapi.com/?");
        foreach (var prop in obj.GetType().GetProperties())
        {
            // check if this property has the custom attribute
            var attr = prop
                .GetCustomAttributes(typeof(ApiElementNameAttribute), false)
                .FirstOrDefault() as ApiElementNameAttribute;
            if (attr != null)
            {
                var key = attr.Name;
                var value = prop.GetValue(obj, null);
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture,
                    "{0}={1}&",
                    key, value);
            }
        }
        // remove trailing ampersand (I presume this is a HTTP GET query)
        if (sb[sb.Length - 1] == '&')
            sb.Length--;
        return sb.ToString();
    }
