    [XmlRoot("Document")]
    public class MetaDataXml
    {
        [XmlArray("Sectors")]
        [XmlArrayItem("Sector")]
        public Sector[] Sectors { get; set; }
    }
    [XmlRoot("Sector")]
    public class Sector
    {
        [XmlIgnore]
        private string _sectorName;
        [XmlText]
        public string SectorName
        {
            get
            {
                return _sectorName;
            }
            set
            {
                _sectorName = value.Trim();
            }
        }
        [XmlArray]
        [XmlArrayItem(ElementName = "Subsector")]
        public List<string> Subsectors { get; set; }
    }
