    public class Text : INotifyPropertyChanged
    {
        private string _title;
    
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
    
        public Text(string name)
        {
            this.Title = name;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    
