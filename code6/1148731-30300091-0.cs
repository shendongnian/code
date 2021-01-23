    [XmlRoot("response")]
    public class SMSResponse
    {
        [XmlArray("sms")]
        [XmlArrayItem("smsid")]
        public List<string> SmsID { get; set; }
    }
