    [XmlRoot(ElementName = "textValue")]
    public class TextValue
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlElement(ElementName = "textValue")]
        public TextValue TextValue { get; set; }
        [XmlElement(ElementName = "textStr")]
        public string TextStr { get; set; }
        [XmlElement(ElementName = "textDate")]
        public TextDate TextDate { get; set; }
    }
    [XmlRoot(ElementName = "variable")]
    public class Variable
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "text")]
        public Text Text { get; set; }
    }
    [XmlRoot(ElementName = "textDate")]
    public class TextDate
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
    }
    [XmlRoot(ElementName = "deviceState")]
    public class DeviceState
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "device")]
        public string Device { get; set; }
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
    }
