    [XmlRoot(ElementName = "SpeedLineMenu")]
    public class SpeedLineMenuXml
    {
        public SpeedLineMenuChildrenXml Children { get; set; }
    }
    public class SpeedLineMenuChildrenXml
    {
        public ValueMealTreeRootXml ValueMealTreeRoot { get; set; }
    }
    public class ValueMealTreeRootXml
    {
        public KeyXml Name { get; set; }
        public KeyXml SequenceID { get; set; }
        public KeyXml IsActive { get; set; }
        public ValueMealTreeRootChildrenXml Children { get; set; }
    }
    public class KeyXml
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    public class ValueMealTreeRootChildrenXml
    {
        public GroupXml Group { get; set; }
    }
    public class GroupXml
    {
        public KeyXml Name { get; set; }
        public KeyXml SequenceID { get; set; }
        public KeyXml IsActive { get; set; }
        public KeyXml Caption { get; set; }
    }
