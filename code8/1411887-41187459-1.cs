    public class Email
    {
        public Email()
        {
            this.State = new EmailState();
        }
    
        internal Email(EmailState state)
        {
            this.State = state;
        }
    
        internal EmailState State { get; set; }
    
        public int Id { get; private set; }
    
        public IEnumerable<Attachment> Attachments()
        {
            return this.State.Resources.Select(x => x.ToAttachment());
        }
    
        public void AddAttachment(Attachment attachment)
        {
            this.State.Resources.Add(attachment.State);
        }      
    }
    
    public class Attachment
    {
        public Attachment()
        {
            this.State = new AttachmentState();
        }
    
        internal Attachment(AttachmentState state)
        {
            this.State = state;
        }
    
        internal AttachmentState State { get; set; }
    }
