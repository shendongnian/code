    public class StringMessageEventBase
    {    
        private string _Message;
        public StringMessageEventBase()
            : this(null) { }
        public StringMessageEventBase(string message)
        {
            _Message = message;
        }
        public string Message
        {
            get { return _Profile; }
            set { _Profile = value; }
        }
    }
    
    public class ViewModelBMessageEvent : StringMessageEventBase
    {
        public ViewModelBMessageEvent(string message)
            : base(profile) {}
    }
