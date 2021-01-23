    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class cXML
    {
        /// <remarks />
        public cXMLHeader Header { get; set; }
    
        /// <remarks />
        public cXMLRequest Request { get; set; }
    
        /// <remarks />
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang { get; set; }
    
        /// <remarks />
        [XmlAttribute]
        public DateTime timestamp { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeader
    {
        /// <remarks />
        public cXMLHeaderFrom From { get; set; }
    
        /// <remarks />
        public cXMLHeaderTO To { get; set; }
    
        /// <remarks />
        public cXMLHeaderSender Sender { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderFrom
    {
        /// <remarks />
        public cXMLHeaderFromCredential Credential { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderFromCredential
    {
        /// <remarks />
        public string Identity { get; set; }
    
        /// <remarks />
        [XmlAttribute]
        public string domain { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderTO
    {
        /// <remarks />
        public cXMLHeaderTOCredential Credential { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderTOCredential
    {
        /// <remarks />
        public string Identity { get; set; }
    
        /// <remarks />
        [XmlAttribute]
        public string domain { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderSender
    {
        /// <remarks />
        public cXMLHeaderSenderCredential Credential { get; set; }
    
        /// <remarks />
        public string UserAgent { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLHeaderSenderCredential
    {
        /// <remarks />
        public string Identity { get; set; }
    
        /// <remarks />
        public string SharedSecret { get; set; }
    
        /// <remarks />
        [XmlAttribute]
        public string domain { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLRequest
    {
        /// <remarks />
        public cXMLRequestPunchOutSetupRequest PunchOutSetupRequest { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLRequestPunchOutSetupRequest
    {
        /// <remarks />
        public string BuyerCookie { get; set; }
    
        /// <remarks />
        public cXMLRequestPunchOutSetupRequestBrowserFormPost BrowserFormPost { get; set; }
    
        /// <remarks />
        [XmlAttribute]
        public string operation { get; set; }
    }
    
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class cXMLRequestPunchOutSetupRequestBrowserFormPost
    {
        /// <remarks />
        public string URL { get; set; }
    }
