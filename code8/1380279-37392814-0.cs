    public class TableCreator:INotifyPropertyChanged
    {
        
        private string yourVariable;
        public string YourVariable
        {
            get { return YourVariable; }
            set {
                YourVariable =value;
                OnPropertyChanged("YourVariable");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
          
    }
