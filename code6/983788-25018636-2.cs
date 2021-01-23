    public static string BuildApiCall(object obj)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("http://mytestapi.com/?");
        foreach (var prop in obj.GetType().GetProperties())
        {
            var attr = prop.GetCustomAttributes(
               typeof(ApiElementNameAttribute), false)
               .FirstOrDefault() as ApiElementNameAttribute;
            if (attr != null)
            {
                var key = attr.Name;
                var value = prop.GetValue(obj, null);
                sb.AppendFormat("{0}={1}", key, value);
            }
        }
        return sb.ToString();
    }
