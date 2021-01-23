    public class myClassConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var myClass = new myClass();
            object data;
            if (dictionary.TryGetValue("data", out data))
            {
                if (data.IsJsonArray())
                {
                    myClass.data = data.AsJsonArray()
                        .Select((o, i) => new KeyValuePair<int, object>(i, o))
                        .ToDictionary(p => p.Key.ToString(NumberFormatInfo.InvariantInfo), p => serializer.ConvertToType<string>(p.Value));
                }
                else if (data.IsJsonObject())
                {
                    myClass.data = data.AsJsonObject()
                        .ToDictionary(p => p.Key, p => serializer.ConvertToType<string>(p.Value));
                }
            }
            return myClass;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new [] { typeof(myClass) }; }
        }
    }
    public static class JavaScriptSerializerObjectExtensions
    {
        public static bool IsJsonArray(this object obj)
        {
            if (obj is string || obj.IsJsonObject())
                return false;
            return obj is IEnumerable;
        }
        public static IEnumerable<object> AsJsonArray(this object obj)
        {
            return (obj as IEnumerable).Cast<object>();
        }
        public static bool IsJsonObject(this object obj)
        {
            return obj is IDictionary<string, object>;
        }
        public static IDictionary<string, object> AsJsonObject(this object obj)
        {
            return obj as IDictionary<string, object>;
        }
    }
