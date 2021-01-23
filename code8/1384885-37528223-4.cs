    public class CommunicationMessage:ISerializable
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public List<CommunicationMessage> Childs { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Key, Value);
            PropertyInfo[] pi=this.GetType().GetProperties();
            foreach(var p in pi)
            {
                if (p.Name == "Key" || p.Name == "Value")
                    continue;
                info.AddValue(p.Name, p.GetValue(this));
            }
        }
    }
