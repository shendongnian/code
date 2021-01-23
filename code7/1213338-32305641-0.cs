    [XmlRoot("response")]
	public abstract class ResponseObject
	{
		[XmlIgnore]
		public bool Success { get; set; }
        [XmlIgnore]
        public string Session
        {
            get
            {
                var result = Values.FirstOrDefault(n => n.Name == "session");
                return result.Value;
            }
        }
        [XmlIgnore]
        public string Status
        {
            get
            {
                var result = Values.FirstOrDefault(n => n.Name == "status");
                return result.Value;
            }
        }
        [XmlIgnore]
        public string Message
        {
            get
            {
                var result = Values.FirstOrDefault(n => n.Name == "message");
                return result.Value;
            }
        }
        [XmlElement("val")]
        public List<ResponseXmlWrapper<string>> Values;
	}
    public class ResponseXmlWrapper<T>
    {
        [XmlAttribute("n")]
        [JsonProperty("n")]
        public string Name { get; set; }
        [XmlText]
        [JsonProperty()]
        public T Value { get; set; }
        public ResponseXmlWrapper()
        {
        }
        public ResponseXmlWrapper(string attributeName, T value)
        {
            Name = attributeName;
            Value = value;
        }
    }
