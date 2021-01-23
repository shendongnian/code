    public class MailItem
    {
        public string UniqueEmailId { get; set; }
        public string SenderEmailId { get; set; }
        [XmlArrayItem("EmailId")]
        public string[] ToRecipientEmailId { get; set; }
    }
