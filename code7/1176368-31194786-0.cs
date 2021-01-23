    public class UInt32ToInt64Serializer : IBsonSerializer
    {
        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return (uint)context.Reader.ReadInt64();
        }
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteInt64((uint)value);
        }
        public Type ValueType { get { return typeof (uint); } }
    }
