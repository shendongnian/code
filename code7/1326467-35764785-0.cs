    public static class ObjectExtensions
    {
        public static string ToStringWithReflection<T>(this T obj)
        {
            if (obj == null)
                return string.Empty;
            var type = obj.GetType();
            var fields = type.GetFields();
            var properties = type.GetProperties().Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod(true) != null);
            var values = new List<KeyValuePair<string, object>>();
            Array.ForEach(fields, (field) => values.Add(new KeyValuePair<string, object>(field.Name, field.GetValue(obj))));
            foreach (var property in properties)
                if (property.CanRead)
                    values.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(obj, null)));
            return values.Aggregate(new StringBuilder(), (s, pair) => (s.Length == 0 ? s.Append("{").Append(obj.GetType().Name).Append(": ") : s.Append("; ")).Append(pair)).Append("}").ToString();
        }
    }
