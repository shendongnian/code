    public class Recepient
    {
        public int EntryType { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
    
    public class Mail
    {
        public List<Recepient> To { get; set; }
        public List<Recepient> Cc { get; set; }
        public List<Recepient> Bcc { get; set; }
    }
