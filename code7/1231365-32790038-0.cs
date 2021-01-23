    public class StringRemappingContractResolver : DefaultContractResolver
    {
        static readonly object NullValue;
        static StringRemappingContractResolver() { NullValue = new object(); }
        readonly Dictionary<object, object> map;
        readonly ILookup<object, object> reverseMap;
        public StringRemappingContractResolver() : this(new KeyValuePair<object, object> [] { new KeyValuePair<object, object>(null, "-")}) 
        {
        }
        public StringRemappingContractResolver(IEnumerable<KeyValuePair<object, object>> map)
        {
            if (map == null)
                throw new ArgumentNullException("map");
            this.map = map.ToDictionary(p => p.Key ?? NullValue, p => p.Value);
            this.reverseMap = map.ToLookup(p => p.Value ?? NullValue, p => p.Key);
        }
        class StringRemappingValueProvider : IValueProvider
        {
            readonly IValueProvider baseProvider;
            readonly Dictionary<object, object> map;
            readonly ILookup<object, object> reverseMap;
            public StringRemappingValueProvider(IValueProvider baseProvider, Dictionary<object, object> map, ILookup<object, object> reverseMap)
            {
                if (baseProvider == null)
                    throw new ArgumentNullException("baseProvider");
                this.baseProvider = baseProvider;
                this.map = map;
                this.reverseMap = reverseMap;
            }
            #region IValueProvider Members
            public object GetValue(object target)
            {
                var value = baseProvider.GetValue(target);
                object mapped;
                if (map.TryGetValue(value ?? NullValue, out mapped))
                    value = mapped;
                return value;
            }
            public void SetValue(object target, object value)
            {
                foreach (var mapped in reverseMap[value ?? NullValue])
                {
                    // Use the first.
                    value = mapped;
                    break;
                }
                baseProvider.SetValue(target, value);
            }
            #endregion
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType == typeof(string))
            {
                property.ValueProvider = new StringRemappingValueProvider(property.ValueProvider, map, reverseMap);
            }
            return property;
        }
    }
