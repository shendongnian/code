    public class Root
    {
        [XmlIgnore]
        public byte[] Bytes { get; set; }
        [XmlText]
        public string Base64Bytes
        {
            get
            {
                return Bytes == null ? null : Convert.ToBase64String(Bytes);
            }
            set
            {
                Bytes = value == null ? null : Convert.FromBase64String(value);
            }
        }
        [XmlElement]
        public List<string> List { get; set; }
    }
