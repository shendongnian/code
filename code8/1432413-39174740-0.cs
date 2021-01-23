    public class UserDataSerializer : SerializerBase<UserData>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, UserData value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteName("Id");
            context.Writer.WriteInt32(value.Id);
            context.Writer.WriteName("Name");
            context.Writer.WriteString(value.Name);
            WriteKeyValue(context.Writer, value.Custom1);
            WriteKeyValue(context.Writer, value.Custom2);
            context.Writer.WriteEndDocument();
        }
        private void WriteKeyValue(IBsonWriter writer, KeyValuePair<string, double> kv)
        {
            writer.WriteName(kv.Key);
            writer.WriteDouble(kv.Value);
        }
        public override UserData Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            //TODO: implement data deserialization using context.Reader
            throw new NotImplementedException();
        }
    }
