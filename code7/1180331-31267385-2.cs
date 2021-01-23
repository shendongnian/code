    [XmlRoot("Response", Namespace = "http://Microsoft.LobServices.Sap/2007/03/Rfc/")]
    public class Response
    {
        [XmlArray("E_ARR")]
        [XmlArrayItem(typeof (ITEM), ElementName = "ITEM", Namespace = "http://Microsoft.LobServices.Sap/2007/03/Types/Rfc/")]
        public ITEM[] E_ARR { get; set; }
    }
    
    public class ITEM
    {
        [XmlElement]
        public string PROPA { get; set; }
    
        [XmlElement]
        public string PROPB { get; set; }
    }
