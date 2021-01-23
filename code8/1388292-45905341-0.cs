    public class JsonDefaultValueAttribute : DefaultValueAttribute
    {
        public JsonDefaultValue(string json, Type type) : base (ConvertFromJson(json, type))
        {            
        }
    
        private static object ConvertFromJson(string json, Type type)
        {
            var value = JsonConvert.DeserializeObject(json, type, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Populate
            });
    
            return value;
        }
        ....
    }
