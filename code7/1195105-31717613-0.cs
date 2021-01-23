    public class TextChangedEventArgs : EventArgs
    {
        public string PreviousText;
        public string CurrentText;
        public TextChangedEventArgs(string previousText, string currentText)
        {
            PreviousText = previousText;
            CurrentText = currentText;
        }
    }
    public delegate void TextChangedEventHandler(Object sender, TextChangedEventArgs e);
