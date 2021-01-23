    public class MailMessage : IDisposable
    {
        public MailMessage();
        public MailMessage(string from, string to);
        public MailMessage(MailAddress from, MailAddress to);
        public MailMessage(string from, string to, string subject, string body);
        public AlternateViewCollection AlternateViews { get; }
        public AttachmentCollection Attachments { get; }
        public MailAddressCollection Bcc { get; }
    }
