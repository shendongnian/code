    [XmlRoot("Options")]
    public class Options
    {
        [XmlElement("Option")] // <-- This introduces an additional nested <Option> element.
        public string Option { get; set; }
    }
