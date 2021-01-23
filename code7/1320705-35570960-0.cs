    public class Entry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
    
        DateTime lastUD;
        public DateTime LastUpdated
        {
            get
            {
                return lastUD;
            }
            set
            {
                lastUD = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastUpdated"));
            }
        }
    }
