    public class ItemAddedEventArgs : EventArgs
    {
        public ItemAddedEventArgs(string issue, string comment)
        {
            Issue = issue;
            Comment = comment;
        }
        public string Issue { get; private set; }
        public string Comment { get; private set; }
    }
