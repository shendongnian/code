    public class IncomingMessageEventArgs : EventArgs
    {
        private Message _message;
        public Message Message
        {
            get
            {
                return _message;
            }
        }
        public IncomingMessageEventArgs(Message message)
        {
            _message = message;
        }
    }    
