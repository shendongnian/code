    public static object Get(string value)
    {
        var jToken = JsonConvert.DeserializeObject<JToken>(value);
        if (jToken == null)
            return null;
        else if (jToken is JValue)
        {
            return ((JValue)jToken).Value;
        }
        else
        {
            if (jToken["$type"] == null)
                return null;
            // Use the same serializer settings as used during serialization.
            // Ideally with a proper SerializationBinder that sanitizes incoming types as suggested
            // in https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_TypeNameHandling.htm
            var _settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                TypeNameHandling = TypeNameHandling.All,
                Converters = { new StringEnumConverter() },
                //SerializationBinder = new SafeSerializationBinder(),
            };
            // Since the JSON contains a $type parameter and TypeNameHandling is enabled, if we deserialize 
            // to type object the $type information will be used to determine the actual type, using Json.NET's
            // serialization binder: https://www.newtonsoft.com/json/help/html/SerializeSerializationBinder.htm
            return jToken.ToObject(typeof(object), JsonSerializer.CreateDefault(_settings));
        }
    }
