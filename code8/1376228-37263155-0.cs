    public class Tasks : INotifyPropertyChanged
    {
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("title"); }
        }
        private string _date;
        public string date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("date"); }
        }
        private string _countdown;
        public string countdown
        {
            get { return _countdown; }
            set { _countdown = value; OnPropertyChanged("countdown"); }
        }
        private TimeSpan _timer;
        public TimeSpan timer
        {
            get { return _timer; }
            set { _timer = value; OnPropertyChanged("timer"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
            {
                e.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
