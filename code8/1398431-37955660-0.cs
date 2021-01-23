    class ResultConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type> { typeof(Result) }; }
        }
        public override object Deserialize(IDictionary<string, object> dict, Type type, JavaScriptSerializer serializer)
        {
            Result result = new Result();
            result.upon_approval = GetValue<string>(dict, "upon_approval");
            var locDict = GetValue<IDictionary<string, object>>(dict, "location");
            if (locDict != null)
            {
                Location loc = new Location();
                loc.display_value = GetValue<string>(locDict, "display_value");
                loc.link = GetValue<string>(locDict, "link");
                result.location = loc;
            }
            result.expected_start = GetValue<string>(dict, "expected_start");
            return result;
        }
        private T GetValue<T>(IDictionary<string, object> dict, string key)
        {
            object value = null;
            dict.TryGetValue(key, out value);
            return value != null && typeof(T).IsAssignableFrom(value.GetType()) ? (T)value : default(T);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
