    public class Message
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public virtual User User { get; set; }
    }
