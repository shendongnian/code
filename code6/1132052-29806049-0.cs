    public class example
    {
        public string abc;
        public someOtherDataType xyz;
    }
    // Example implementation only.
    public class someOtherDataType
    {
        public string SomeProperty { get; set; }
        public static someOtherDataType CreateFromJsonObject(object xyzValue)
        {
            if (xyzValue is string)
            {
                return new someOtherDataType { SomeProperty = (string)xyzValue };
            }
            return null;
        }
    }
    class exampleConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(example) }; }
        }
        // Custom conversion code below
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var defaultDict = dictionary.Where(pair => pair.Key != "xyz").ToDictionary(pair => pair.Key, pair => pair.Value);
            var overrideDict = dictionary.Where(pair => !(pair.Key != "xyz")).ToDictionary(pair => pair.Key, pair => pair.Value);
            // Use a "fresh" JavaScriptSerializer here to avoid infinite recursion.
            var value = (example)new JavaScriptSerializer().ConvertToType<example>(defaultDict);
            object xyzValue;
            if (overrideDict.TryGetValue("xyz", out xyzValue))
            {
                value.xyz = someOtherDataType.CreateFromJsonObject(xyzValue);
            }
            return value;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
