    public class InterfaceToConcreteGenericJsonConverter : JsonConverter
    {
        readonly Type GenericTypeDefinition;
        public InterfaceToConcreteGenericJsonConverter(Type genericTypeDefinition)
        {
            if (genericTypeDefinition == null)
                throw new ArgumentNullException();
            this.GenericTypeDefinition = genericTypeDefinition;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        Type MakeGenericType(Type objectType)
        {
            if (!GenericTypeDefinition.IsGenericTypeDefinition)
                return GenericTypeDefinition;
            try
            {
                var parameters = objectType.GetGenericArguments();
                return GenericTypeDefinition.MakeGenericType(parameters);
            }
            catch (Exception ex)
            {
                // Wrap the reflection exception in something more useful.
                throw new JsonSerializationException(string.Format("Unable to construct concrete type from generic {0} and desired type {1}", GenericTypeDefinition, objectType), ex);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, MakeGenericType(objectType));
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
