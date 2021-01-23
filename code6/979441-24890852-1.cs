    private static string ToStringOrDefault<T>(T item, string replacement = "null")
    {
        return IsNull(item) ? replacement : item.ToString();
    }
    sb.Append(ToStringOrDefault(nullableInt));
