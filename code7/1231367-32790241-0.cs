    public class NullStringReplacementResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // Attach a NullStringReplacementProvider instance to each string property
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null)
                {
                    prop.ValueProvider = new NullStringReplacementProvider(pi);
                }
            }
            return props;
        }
        protected class NullStringReplacementProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            public NullStringReplacementProvider(PropertyInfo targetProperty)
            {
                this.targetProperty = targetProperty;
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the string;
            // the return value is the string that gets written to the JSON
            public object GetValue(object target)
            {
                // if the value of the target property is null, replace it with "-"
                string s = (string)targetProperty.GetValue(target);
                return (s == null ? "-" : s);
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the original value read from the JSON;
            // target is the object on which to set the value.
            public void SetValue(object target, object value)
            {
                // if the value in the JSON is "-" replace it with null
                string s = (string)value;
                targetProperty.SetValue(target, s == "-" ? null : s);
            }
        }
    }
