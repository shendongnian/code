    public class Data : INotifyPropertyChanged
    {
        int random;
        public int Random
        {
            get { return random;  }
            set { random = value; NotifyPropertyChanged("Random"); }
        }
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
