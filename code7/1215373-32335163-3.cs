    public class BirthdayEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public BirthdayEventArgs(string message) { Message = message; }
    }
