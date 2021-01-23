    public enum MessageType { StatusText, MessageBox }
    public NotifyEventArgs: EventArgs
    {
        public MessageType Type { get; }
        public string Message { get; }
        public NotifyEventArgs(MessageType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
    public static NotifyManager
    {
        public event EventHandler<NotifyMessageArgs> Notify;
        public static OnEventHandler(MessageType type, string message) =>
            Notify?.Invoke(null, new NotifyEventArgs(type, message));
    }
