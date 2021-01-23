    public static string GenerateQueryStringWithParameters(this OptionalParameter optionalParameter)
    {
        var props = optionalParameter.GetType().GetProperties()
            .Select(x => new { Prop = x, Attr = x.GetCustomAttribute<EntityOptionalParameter>() })
            .Where(x => x.Attr != null); // Get all properties that have the attribute
        var sb = new StringBuilder("?");
        var first = true;
        foreach(var prop in props) // Loop through properties
        {
            if (first)
            {
                first = false;
            }
            else
            {
                sb.Append("&")
            }
            sb.Append(prop.Attr.ParameterName); // Append property name
            sb.Append("=");
            sb.Append(prop.Prop.GetValue(optionalParameter)); // Append property value
        }
        return sb.ToString()
    }
