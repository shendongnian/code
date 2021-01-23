    [DataContractAttribute]
    public class Data
    {
        private string[] messages;
    
        [DataMember(Name = "messages")]
        public string[] Messages
        {
            get
            {
                return messages;
            }
    
            set
            {
                messages = value;
            }
        }
    
        [DataMember(Name = "m")]
        public string[] AlternativeMessages
        {
            get
            {
                return messages;
            }
    
            set
            {
                messages = value;
            }
        }
    
        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }
    
        [DataMember(Name = "request")]
        public int Request { get; set; }
    }
    
    public class JsonUtils
    {
        public static T JsonDeserialize<T>(string jsonString)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
        
    var value = "{ \"m\": [\"Hi!\", \"Prix\"], \"timestamp\": 123456, \"request\": 1 }";
    
    var data = JsonHandler.JsonDeserialize<Data>(value);
