    [XmlRoot("replyMessage", Namespace= "urn:schemas-cybersource-com:transaction-data-1.118")]
    public class CReplyMessage
    {
        [XmlElement(ElementName = "merchantReferenceCode")]
        public string MerchantReferenceCode { get; set; }
    
        [XmlElement(ElementName = "requestID")]
        public string RequestID { get; set; }
    
        [XmlElement(ElementName = "caseManagementActionReply")]
        public CCaseManagementActionReply CaseManagementActionReply { get; set; }
    }
