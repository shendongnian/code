    [Serializable]
    public class filters
    {
        public List<string> key1 { get; set; }
        public List<string> key2 { get; set; }
        public List<string> key3 { get; set; }
    }
    class filtersConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var filters = new filters();
            filters.key1 = serializer.FromSingleOrArray<string>(dictionary, "key1");
            filters.key2 = serializer.FromSingleOrArray<string>(dictionary, "key2");
            filters.key3 = serializer.FromSingleOrArray<string>(dictionary, "key3");
            return filters;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (obj == null)
                return null;
            var filters = (filters)obj;
            var dictionary = new Dictionary<string, object>();
            filters.key1.ToSingleOrArray(dictionary, "key1");
            filters.key2.ToSingleOrArray(dictionary, "key2");
            filters.key3.ToSingleOrArray(dictionary, "key3");
            return dictionary;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(filters) }; }
        }
    }
    public static class JavaScriptSerializerObjectExtensions
    {
        public static void ToSingleOrArray<T>(this ICollection<T> list, IDictionary<string, object> dictionary, string key)
        {
            if (list == null || list.Count == 0)
                return;
            if (list.Count == 1)
                dictionary.Add(key, list.First());
            else
                dictionary.Add(key, list);
        }
        public static List<T> FromSingleOrArray<T>(this JavaScriptSerializer serializer, IDictionary<string, object> dictionary, string key)
        {
            object value;
            if (!dictionary.TryGetValue(key, out value))
                return null;
            return serializer.FromSingleOrArray<T>(value);
        }
        public static List<T> FromSingleOrArray<T>(this JavaScriptSerializer serializer, object value)
        {
            if (value == null)
                return null;
            if (value.IsJsonArray())
            {
                return value.AsJsonArray().Select(i => serializer.ConvertToType<T>(i)).ToList();
            }
            else
            {
                return new List<T> { serializer.ConvertToType<T>(value) };
            }
        }
        public static bool IsJsonArray(this object obj)
        {
            if (obj is string || obj is IDictionary)
                return false;
            return obj is IEnumerable;
        }
        public static IEnumerable<object> AsJsonArray(this object obj)
        {
            return (obj as IEnumerable).Cast<object>();
        }
    }
