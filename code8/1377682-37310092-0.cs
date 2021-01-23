    [XmlRoot("Options")]
    public class Options
    {
        [XmlElement("Option")] // <-- This introduces an additional nested <Options> element.
        public string Option { get; set; }
    }
