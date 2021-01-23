    public class BoolStringClass : INotifyPropertyChanged
    {
        private bool _thevalue;
        public event PropertyChangedEventHandler PropertyChanged;
        public string TheText { get; set; }
        public bool TheValue
        {
            get
            {
                 return _thevalue;
            }
            set
            {
                 _thevalue = value;
                 
                 OnPropertyChanged("TheValue")
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
