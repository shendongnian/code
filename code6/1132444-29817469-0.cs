    internal class Range : INotifyPropertyChanged
    {
        private string _value;
        
        public string Value
        {
            get { return _value; }
            set 
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        //Do same for the Description property
        //Do not forgot implement INotifyPropertyChanged interface here
    }
