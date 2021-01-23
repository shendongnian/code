    [Serializable]
    public class Choobakka
    {
        public string Name { get; set; }
        [XmlElement("ElementName")]
        public VariableList<Item> Stuff { get; set; }
    }
