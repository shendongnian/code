    [DataContract]
    public class Message
    {
        public static Message Create(MessageTypeEnum type, params object[] parameters)
        {
            return new Message {MessageType = type, Parameters = parameters};
        }
        [DataMember]
        public MessageTypeEnum MessageType { get; set; }
        public IList<object> Parameters { get; set; }
        [DataMember]
        public IList<string> SerializedParameters
        {
            get { return Parameters.Select(JsonConvert.SerializeObject).ToArray(); }
            set { Parameters = value.Select(DeserializeObject).ToArray(); }
        }
        private object DeserializeObject(string json)
        {
            return ReplaceArrays(JsonConvert.DeserializeObject(json));
        }
        private object ReplaceArrays(object obj)
        {
            var dictionary = obj as IDictionary<string, JToken>;
            if (dictionary != null) return dictionary.ToDictionary(kvp => kvp.Key, kvp => ReplaceArrays(kvp.Value));
            var collection = obj as JArray;
            if (collection != null) return collection.Cast<object>().Select(ReplaceArrays).ToArray();
            var jValue = obj as JValue;
            if (jValue != null) return jValue.Value;
            return obj;
        }
    }
(...)
    public void SendMessage(Message message)
    {
       var receivers = GetReceiversByMessageType(Message.MessageType);
       foreach(var receiver in receivers)
       {
          var template = GetMessage(type, receiver.Locale)
          var text = string.Format(template, receiver.Locale, Message.Parameters);
          SendMessage(receiver.Address, text);
       }
    }
