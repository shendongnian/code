    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(bool stat)
        {
            Stat= stat;
        }
        public bool Stat { get; private set; }
    }
