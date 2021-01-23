    public class ViewModel : INotifyPropertyChanged
    {
        // INPC implementation is omitted
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged();                    
                    OnPropertyChanged("HasChar");
                }
            }
        }
        private string text;
        public bool HasChar
        {
            get { return !string.IsNullOrEmpty(Text); }
        }
    }
