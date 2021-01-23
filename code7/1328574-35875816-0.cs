    public class genericFieldsListConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[] { typeof(List<genericFieldOptions>) };
            }
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var query = from entry in dictionary
                       let subDictionary = entry.Value.AsJsonObject()
                       where subDictionary != null
                       from subEntry in subDictionary
                       select new genericFieldOptions { option = entry.Key, field = subEntry.Key, value = serializer.ConvertToType<bool>(subEntry.Value) };
            return query.ToList();
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var list = (IList<genericFieldOptions>)obj;
            if (list == null)
                return null;
            return list
                .GroupBy(o => o.option)
                .ToDictionary(g => g.Key, g => (object)g.ToDictionary(o => o.field, o => serializer.Serialize(o.value)));
        }
    }
    public static class JavaScriptSerializerObjectExtensions
    {
        public static bool IsJsonObject(this object obj)
        {
            return obj is IDictionary<string, object>;
        }
        public static IDictionary<string, object> AsJsonObject(this object obj)
        {
            return obj as IDictionary<string, object>;
        }
    }
