    public class NPIList
        {
            [XmlArray("NPI"), XmlArrayItem(typeof(NPIObj), ElementName = "NPI")]
            public List<NPIObj> NPI { get; set; }
        }
