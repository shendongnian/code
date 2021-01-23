    [Serializable]
    public class Item
    {
        [XmlElement("name")]
        public NameElement NameElement { get; set; }
    }
    public class NameElement
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlIgnore]
        public string Name
        {
            get { return String.IsNullOrEmpty(this.Value) ? this.Text : this.Value; } 
            set { this.Value = value; }
        }
    }
