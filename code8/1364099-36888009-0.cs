    public class ParamTableRow:INotifyPropertyChanged
    {
        private string paramName;
        public string ParamName
        {
            get { return paramName; }
            set {
                paramName = value;
                OnPropertyChanged("ParamName");
            }
        }
        private decimal? paramValue;
        public decimal? ParamValue
        {
            get { return paramValue; }
            set
            {
                paramValue = value;
                OnPropertyChanged("ParamValue");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new  PropertyChangedEventArgs(propertyName));
        }
        
    }
