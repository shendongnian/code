    public static class Extensions
    {
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }
        public static List<Dictionary<string, object>> FilterProperties<T>(this IEnumerable<T> input, IEnumerable<string> properties)
        {
            return input.Select(x =>
            {
                var d = new Dictionary<string, object>();
                foreach (var p in properties)
                {
                    d[p] = x.GetPropertyValue(p);
                }
                return d;
            }).ToList();
        }
    }
