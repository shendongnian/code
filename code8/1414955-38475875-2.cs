    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        // Never use public fields! 
        // Status should be a property which gets and sets
        // the actual private backing field (_status).
        private _status;
        public string Status
        {
            get { return _status; }
            set { if (value != _status) { _status = value; OnPropertyChanged(); } }
        }
    }
