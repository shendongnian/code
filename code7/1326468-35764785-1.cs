    public static class ObjectExtensions
    {
        public static StringBuilder ToStringWithReflection<T>(this T obj, StringBuilder sb)
        {
            sb = sb ?? new StringBuilder();
            if (obj == null)
                return sb;
            if (obj is IEnumerable)
            {
                sb.Append("[");
                var first = true;
                foreach (var item in ((IEnumerable)obj))
                {
                    if (!first)
                        sb.Append(",");
                    sb.Append(item == null ? "" : item.ToString());
                    first = false;
                }
                sb.Append("]");
            }
            else
            {
                var type = obj.GetType();
                var fields = type.GetFields();
                var properties = type.GetProperties().Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod(true) != null && p.CanRead);
                var query = fields
                    .Select(f => new KeyValuePair<string, object>(f.Name, f.GetValue(obj)))
                    .Concat(properties
                        .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(obj, null))));
                sb.Append("{").Append(obj.GetType().Name).Append(": ");
                var first = true;
                foreach (var pair in query)
                {
                    if (!first)
                        sb.Append(", ");
                    sb.Append(pair.Key).Append(": ");
                    if (pair.Value is IEnumerable && !(pair.Value is string))
                        pair.Value.ToStringWithReflection(sb);
                    else
                        sb.Append(pair.Value == null ? "null" : pair.Value.ToString());
                    first = false;
                }
                sb.Append("}");
            }
            return sb;
        }
        public static string ToStringWithReflection<T>(this T obj)
        {
            return obj.ToStringWithReflection(new StringBuilder()).ToString();
        }
    }
