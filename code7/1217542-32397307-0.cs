    public  class items
    {
        [JsonProperty(PropertyName = "frequency")]
        [XmlElement(ElementName = "frequency", IsNullable = true)]
        public string Frequency { get; set; }
        [JsonProperty(PropertyName = "modulation")]
        [XmlElement(ElementName = "modulation", IsNullable = true)]
        public string Modulation { get; set; }
    }
