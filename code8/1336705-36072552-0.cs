    public class Wrapper : INotifyPropertyChanged
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        //INotifyPropertyChanged implementation...
    }
