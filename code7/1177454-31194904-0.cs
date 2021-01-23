    public class LocalTimeSerializer : IBsonSerializer
    {
        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return context.Reader.ReadDateTime();
        }
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteDateTime(((DateTime)value).ToLocalTime().Ticks);
        }
        public Type ValueType { get { return typeof(DateTime); } }
    }
