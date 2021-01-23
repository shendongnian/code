    public class EnableJsonTypeNameHandlingConverter : JsonConverter
    {
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
        public override bool CanConvert(Type objectType)
        {
            if (Disabled)
                return false;
            if (objectType.Assembly.GetCustomAttributes<EnableJsonTypeNameHandlingAttribute>().Any())
                return true;
            if (objectType.GetCustomAttributes<EnableJsonTypeNameHandlingAttribute>(true).Any())
                return true;
            foreach (var type in objectType.GetInterfaces())
                if (type.GetCustomAttributes<EnableJsonTypeNameHandlingAttribute>(true).Any())
                    return true;
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val)) // Prevent infinite recursion of converters
            using (new PushValue<TypeNameHandling>(TypeNameHandling.Auto, () => serializer.TypeNameHandling, val => serializer.TypeNameHandling = val))
            {
                return serializer.Deserialize(reader, objectType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val)) // Prevent infinite recursion of converters
            using (new PushValue<TypeNameHandling>(TypeNameHandling.Auto, () => serializer.TypeNameHandling, val => serializer.TypeNameHandling = val))
            {
                // Force the $type to be written unconditionally by passing typeof(object) as the type being serialized.
                serializer.Serialize(writer, value, typeof(object));
            }
        }
    }
    [System.AttributeUsage(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Interface)]
    public class EnableJsonTypeNameHandlingAttribute : System.Attribute
    {
        public EnableJsonTypeNameHandlingAttribute()
        {
        }
    }
