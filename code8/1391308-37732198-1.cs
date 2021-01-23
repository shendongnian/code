    [Serializable, XmlRoot("ctatt")]
    public class trainDataResult
    {
        [XmlElement(ElementName ="tmst")]
        public string timeStamp { get; set; }
    
        [XmlElement(ElementName = "errCd")]
        public byte errorCode { get; set; }
    
        // uncomment next lines to include `errNm`
        //[XmlElement(ElementName = "errNm")]
        //public string errorName { get; set; }
    
        [XmlElement(ElementName = "eta")]
        public TrainData eta { get; set; }
    }
    
    public class TrainData
    {
        [XmlElement(ElementName = "staId")]
        public ushort stationId { get; set; }
    
        [XmlElement(ElementName = "stpId")]
        public ushort stopId { get; set; }
    
        [XmlElement(ElementName = "staNm")]
        public string stationName { get; set; }
    
        [XmlElement(ElementName = "stpDe")]
        public string stopDesc { get; set; }
    
        [XmlElement(ElementName = "rn")]
        public ushort runNum { get; set; }
    
        [XmlElement(ElementName = "rt")]
        public string routeName { get; set; }
    
        [XmlElement(ElementName = "destSt")]
        public ushort destStation { get; set; }
    
        [XmlElement(ElementName = "destNm")]
        public string destName { get; set; }
    
        [XmlElement(ElementName = "trDr")]
        public byte trainDir { get; set; }
    
        [XmlElement(ElementName = "prdt")]
        public string prdTime {get; set;}
    
        [XmlElement(ElementName = "arrT")]
        public string arrTime { get; set; }
    
        [XmlElement(ElementName = "isApp")]
        public ushort isApp { get; set; }
    
        [XmlElement(ElementName = "isSch")]
        public ushort isSch { get; set; }
    
        [XmlElement(ElementName = "isDly")]
        public ushort isDly { get; set; }
    
        [XmlElement(ElementName = "isFlt")]
        public ushort isFlt { get; set; }
    
        [XmlElement(ElementName = "flags")]
        public string flags { get; set; }
    
        [XmlElement(ElementName = "lat")]
        public double lat { get; set; }
    
        [XmlElement(ElementName = "lon")]
        public double lon { get; set; }
    
        [XmlElement(ElementName = "heading")]
        public ushort heading { get; set; }
    }
