    public class DataClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ObservableCollection<string> collection;
        public ObservableCollection<string> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }       
    }
