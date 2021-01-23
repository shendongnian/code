    public class MailObject
        {
            public ICollection<MailPersonalizations> personalizations { get; set; }
            public Email from { get; set; }
            public string template_id { get; set; }
            //public ICollection<MailContent> content { get; set; }
        }
    public class MailPersonalizations
        {
            public ICollection<Email> to { get; set; }
            public string subject { get; set; }
            public Dictionary<string, string> substitutions { get; set; }
        }
    public class MailContent
        {
            public string type { get; set; }
            public string value { get; set; }
        }
    public class Email
        {
            public string email { get; set; }
            public string name { get; set; }
        }
