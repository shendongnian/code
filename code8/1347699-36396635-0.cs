    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            StartTime = DateTime.Now;
            UpdateTime = new RelayCommand( UpdateElapsedTime, new Func<bool>(() => { return true; }));
        }
        public DateTime StartTime { get; set; }
        private double _elapsedTime;
        public double ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = value; RaisePropertyChanged("ElapsedTime"); }
        }
        public ICommand UpdateTime { get; set; }
        private void UpdateElapsedTime()
        {
            ElapsedTime = (DateTime.Now - StartTime).TotalSeconds;
        }
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
