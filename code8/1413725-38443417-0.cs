    class MyObjectConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(MyObject) }; }
        }
        // Custom conversion code below
        const string myPropName = "MyProp";
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            object value;
            if (dictionary.TryGetValue(myPropName, out value))
            {
                dictionary[myPropName] = !value.IsNullOrDefault();
            }
            var myObj = new JavaScriptSerializer().ConvertToType<MyObject>(dictionary);
            return myObj;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var myObj = (MyObject)obj;
            // Generate a default serialization.  Is there an easier way to do this?
            var defaultSerializer = new JavaScriptSerializer();
            var dict = defaultSerializer.Deserialize<Dictionary<string, object>>(defaultSerializer.Serialize(obj));
            dict[myPropName] = myObj.MyProp ? 1 : 0;
            return dict;
        }
    }
    public static class ObjectExtensions
    {
        public static bool IsNullOrDefault(this object value)
        {
            // Adapted from https://stackoverflow.com/questions/6553183/check-to-see-if-a-given-object-reference-or-value-type-is-equal-to-its-default
            if (value == null)
                return true;
            Type type = value.GetType();
            if (!type.IsValueType)
                return false; // can't be, as would be null
            if (Nullable.GetUnderlyingType(type) != null)
                return false; // ditto, Nullable<T>
            object defaultValue = Activator.CreateInstance(type); // must exist for structs
            return value.Equals(defaultValue);
        }
    }
