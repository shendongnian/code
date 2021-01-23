    //JsonSerializer.cs
    public static class JsonSerializer
    {
        public static string Serialize(object target, bool ignoreNulls = true)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            if (ignoreNulls)
            {
                javaScriptSerializer.RegisterConverters(new[] 
                {
                    new NullExclusionConverter(target)
                });
            }
            return javaScriptSerializer.Serialize(target);
        }
    }
    //NullExclusionConverter.cs
    public class NullExclusionConverter : JavaScriptConverter
    {
        private readonly Type _type;
    
        public NullExclusionConverter(object target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            this._type = target.GetType();
        }
    
            
    
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override IEnumerable<Type> SupportedTypes
        {
            get 
            { 
                return new[] { this._type };
            }
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var result = new Dictionary<string, object>();
            if (obj == null)
            {
                return result;
            }
            var properties = obj.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                //Use propertyInfo.Name to exclude a specific property name
                if (propertyInfo.GetValue(obj, null) == null)
                {
                    continue;
                }
                result.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
            }
            return result;
        }
    }
