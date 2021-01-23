    [XmlRoot("response")]
    public class SMSResponse
    {
        [XmlElement("sms")]
        public SMS Sms { get; set; }
    }
    
    public class SMS
    {
        [XmlElement("smsid")]
        public List<string> SmsID { get; set; }
    }
