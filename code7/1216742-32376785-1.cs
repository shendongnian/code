    [DataContract]
    public class MyMessageBase
    {
        [DataMember]
        public int MessageType { get; set; }
        [DataMember]
        public int Enabled { get; set; }
        public MyMessageBase(int messageType, int enabled)            
        {
            MessageType = messageType;
            Enabled = enabled;
        }
        public MyMessageBase() { }
    }
