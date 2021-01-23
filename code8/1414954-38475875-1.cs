    public class Model : INotifyPropertyChanged
    {
        // this is the event which gets fired
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        // you need to raise the event in each property's setter
        private _someValue;
        public string SomeValue
        {
            get { return _someValue; }
            set { if (value != _someValue) { _someValue = value; OnPropertyChanged(); } }
        }
        
        private _anotherVal;
        public string AnotherValue
        {
            get { return _anotherVal; }
            set { if (value != _anotherVal) { _anotherVal = value; OnPropertyChanged(); } }
        }
    }
