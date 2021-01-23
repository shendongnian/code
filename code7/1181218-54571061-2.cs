    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement("DataItem")]
        public DataItem[] Items { get; set; }
    }
    public class DataItem : DynamicAttributes
    {
        [XmlIgnore]
        public string Id
        { 
            get
            {                
                return this.TryGetValue("Id", out var value) ? value.ToString() : null;
            } 
        }
    }
