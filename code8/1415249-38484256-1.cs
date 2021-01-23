    public class EmailClass
    {
        public EmailClass(string sender, string receiver, string message)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Message = message;
        }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message{ get; set; }    
    }
