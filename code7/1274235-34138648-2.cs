    public class Order
    {
        [JsonProperty]
        public int OrderId { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public int Type { get; set; }
        [JsonProperty]
        public decimal Amount { get; set; }
        [JsonProperty]
        public DateTime Date { get; set; }
        [DataMember]
        [JsonProperty]
        [XmlIgnore] // Do not serialize directly
        [XmlWrapCData] // Instead include in CDATA nodes
        public List<Option> ListB { get; set; }
        [DataMember]
        public List<string> ListC { get; set; }
        [XmlIgnore] // Do not serialize directly
        [XmlWrapCData] // Instead include in CDATA nodes
        public Product Product { get; set; }
        [XmlText] // NECESSARY TO EMIT CDATA NODES
        [IgnoreDataMember]
        [JsonIgnore]
        public XmlNode[] CDataContent
        {
            get
            {
                return XmlWrapCDataHelper.GetCDataContent(this);
            }
            set
            {
                XmlWrapCDataHelper.SetCDataContent(this, value);
            }
        }
    }
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class Option
    {
        public string OptionValue { get; set; }
        public string OptionName { get; set; }
    }
