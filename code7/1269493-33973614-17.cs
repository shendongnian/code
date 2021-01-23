    public class Entry : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; this.OnPropertyChanged("Title"); }
        }
        private ObservableCollection<Weekday> days = new ObservableCollection<Weekday>();
        public ObservableCollection<Weekday> Days
        {
            get { return days; }
            set { days = value; this.OnPropertyChanged("Days"); }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
