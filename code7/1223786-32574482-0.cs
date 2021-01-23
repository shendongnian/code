    public class PushNotes : INotifyPropertyChanged
    {
        string completePushNotes;
        public string CompletePushNotes
        {
            get
            {
                return completePushNotes;
            }
    
            set
            {
                completePushNotes = value;
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
