    public class Event<TDetails>
    {
        public Type type { get; set; }
        public TDetails details { get; set; }
    }
    class SendEvent : Event<SendDetails>
    {
        public SendEvent()
        {
            this.type = Type.Send;
        }
    }
