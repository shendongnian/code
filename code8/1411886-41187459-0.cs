    public class EmailState
    {
        public int Id { get; private set; }
    
        public List<AttachmentState> Resources { get; set; }
    
        public static Email ToEmail(EmailState state)
        {
            return new Email(state);
        }
    }
    
    public class AttachmentState
    {
        public static Attachment ToAttachment(AttachmentState state)
        {
            return new Attachment(state);
        }
    
        public Attachment ToAttachment()
        {
            return new Attachment(this);
        }
    }
