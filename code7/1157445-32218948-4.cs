    public class TestClientBuilder : IXunitSerializable
    {
        private string type;
    
        // required for deserializer
        public TestClientBuilder()
        {
        }
    
        public TestClientBuilder(string type)
        {
            this.type = type;
        }
    
        public Impl.Client Build()
        {
            return new Impl.Client(type);
        }
    
        public void Deserialize(IXunitSerializationInfo info)
        {
            type = info.GetValue<string>("type");
        }
    
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("type", type, typeof(string));
        }
    
        public override string ToString()
        {
            return $"Type = {type}";
        }
    }
