    public class Source : INotifyPropertyChanged
    {
        private string _headerText2;
    
        public string HeaderText2
        {
            get { return _headerText2; }
            set
            {
                _headerText2 = value;
                OnPropertyChanged("HeaderText2");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
