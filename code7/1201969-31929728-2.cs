    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = false)]
    public sealed class JsonCustomReadAttribute : Attribute
    {
    }
    public abstract class JsonCustomReadConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException("invalid type " + objectType.FullName);
            var value = existingValue ?? contract.DefaultCreator();
            var jObj = JObject.Load(reader);
            // Split out the properties requiring custom handling
            var extracted = contract.Properties
                .Where(p => p.AttributeProvider.GetAttributes(typeof(JsonCustomReadAttribute), true).Count > 0)
                .Select(p => jObj.ExtractProperty(p.PropertyName))
                .Where(t => t != null)
                .ToList();
            // Populare the properties not requiring custom handling.
            using (var subReader = jObj.CreateReader())
                serializer.Populate(subReader, value);
            ReadCustom(value, new JObject(extracted), serializer);
            return value;
        }
        protected abstract void ReadCustom(object value, JObject jObject, JsonSerializer serializer);
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class JsonExtensions
    {
        public static JProperty ExtractProperty(this JObject obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException();
            var property = obj.Property(name);
            if (property == null)
                return null;
            property.Remove();
            return property;
        }
    }
