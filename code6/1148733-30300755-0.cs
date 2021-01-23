    [XmlRoot("response")]
    public class SMSResponse
    {
        [XmlArray(ElementName = "sms")]
        [XmlArrayItem(ElementName = "smsid", Type = typeof(smsid))]
        public List<smsid> Sms { get; set; }
    }
    public class smsid
    {
        [XmlText]
        public string SmsID { get; set; }
    }
