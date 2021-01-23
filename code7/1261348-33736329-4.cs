    public class CustomEvent : EventArgs
    {
        public CustomEvent(bool stat)
        {
            Stat = stat;
        }
        public bool Stat { get; set; }
    }
