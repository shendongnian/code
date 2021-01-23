    public class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // Find all string properties that do not have an [AllowHtml] attribute applied
            // and attach an HtmlEncodingValueProvider instance to them
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null && pi.GetCustomAttribute(typeof(AllowHtmlAttribute), true) == null)
                {
                    prop.ValueProvider = new HtmlEncodingValueProvider(pi);
                }
            }
            return props;
        }
        protected class HtmlEncodingValueProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            public HtmlEncodingValueProvider(PropertyInfo targetProperty)
            {
                this.targetProperty = targetProperty;
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the original value read from the JSON;
            // target is the object on which to set the value.
            public void SetValue(object target, object value)
            {
                var encoded = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode((string)value, useNamedEntities: true);
                targetProperty.SetValue(target, encoded);
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the string;
            // the return value is the string that gets written to the JSON
            public object GetValue(object target)
            {
                return targetProperty.GetValue(target);
            }
        }
    }
