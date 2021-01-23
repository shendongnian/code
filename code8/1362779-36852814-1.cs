    public delegate void TitleChangedEvent(object sender, TitleChangedEventArgs args);
    public class TitleChangedEventArgs : EventArgs
    {
        public string NewTitle { get; set; }
        public string OldTitle { get; set; }
        public TitleChangedEventArgs(string newTitle, string oldTitle)
        {
            NewTitle = newTitle;
            OldTitle = oldTitle;
        }
    }
