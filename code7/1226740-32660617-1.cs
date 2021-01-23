    [Serializable, XmlRoot(Namespace = "urn:CBI:xsd:CBISDDStsRptPhyMsg.00.01.00")]
    public class CBISDDStsRptPhyMsg
    {
        [XmlElement("CBIHdrTrt", Namespace = "urn:CBI:xsd:CBISDDStsRptPhyMsg.00.01.00")]
        public CBIHdrTrt CBIHdrTrt { get; set; }
        [XmlElement("CBIHdrSrv", Namespace = "urn:CBI:xsd:CBISDDStsRptPhyMsg.00.01.00")]
        public CBIHdrSrv CBIHdrSrv { get; set; }
        [XmlElement("CBIBdySDDStsRpt", Namespace = "urn:CBI:xsd:CBISDDStsRptPhyMsg.00.01.00")]
        public CBIBdySDDStsRpt CBIBdySDDStsRpt { get; set; }
    }
