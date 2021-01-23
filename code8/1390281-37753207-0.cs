    public class YourObject : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string Name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(Name));
            }
        }
        private string _p1;
        public string p1
        {
            get { return _p1; }
            set
            {
                if (_p1 != value)
                {
                    _p1 = value;
                    OnPropertyChanged("p1");
                }
            }
        }
        private string _p2;
        public string p2
        {
            get { return _p2; }
            set
            {
                if (_p2 != value)
                {
                    _p2 = value;
                    OnPropertyChanged("p2");
                }
            }
        }
    }
