    public class MyCustomArraySerializer : SerializerBase<Coordinate>
    {
        public override Coordinate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartArray();
            var lat=context.Reader.ReadDouble();
            var lon = context.Reader.ReadDouble();
            context.Reader.ReadEndArray();
            return new Coordinate() { Long = (float)lon, Lat = (float)lat };
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Coordinate value)
        {
            context.Writer.WriteStartArray();
            context.Writer.WriteDouble(value.Lat);
            context.Writer.WriteDouble(value.Long);
            context.Writer.WriteEndArray();
        }
    }
