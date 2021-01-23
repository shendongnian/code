    [XmlRoot("Response", Namespace="http://Microsoft.LobServices.Sap/2007/03/Rfc/")]
    public class Response
    {
        [XmlArray("E_ARR", Namespace = "http://Microsoft.LobServices.Sap/2007/03/Rfc/")]
        [XmlArrayItem(typeof(ITEM), ElementName = "ITEM", Namespace="http://Microsoft.LobServices.Sap/2007/03/Types/Rfc/")]
        public ITEM[] E_ARR{ get; set; }
    }
    
    public class ITEM
    {
        [XmlElement(Namespace = "http://Microsoft.LobServices.Sap/2007/03/Types/Rfc/")]
        public string PROPA{ get; set; }
    
        [XmlElement(Namespace = "http://Microsoft.LobServices.Sap/2007/03/Types/Rfc/")]
        public string PROPB{ get; set; }
    }
