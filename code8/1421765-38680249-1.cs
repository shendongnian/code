    public class MessageWrapper
    {
        public string MessageType { get; set; }
        public object Message { get; set; }
    }
    var deserialized = JsonConvert.DeserializeObject<MessageWrapper>(serialized);
