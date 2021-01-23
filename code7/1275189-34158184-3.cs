    public class Event<TDetail> where TDetail : Details
    {
        public Type type { get; set; }
        public TDetail details { get; set; }
    }
    public class ReceiveEvent : Event<ReceiveDetails>
    {
       public ReceiveEvent()
        {
            this.type = Type.Recieve;
        }
    }
    public class SendEvent : Event<SendDetails>
    {
        public SendEvent()
        {
            this.type = Type.Send;
        }
    }
