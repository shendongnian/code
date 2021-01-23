    class ExpenseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            var pc = PropertyChanged;
            if (pc != null)
            {
                pc(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void Populate()
        {
            _mySource.Add("Test 1", DateTime.Now);
            _mySource.Add("Test 2", DateTime.Now.AddDays(1));
            _mySource.Add("Test 3", DateTime.Now.AddDays(2));
            _mySource.Add("Test 4", DateTime.Now.AddDays(3));
            NotifyPropertyChanged("MySource");
        }
        private Dictionary<string, DateTime> _mySource;
        public Dictionary<string, DateTime> MySource
        {
            get { return _mySource; }
        }
        public ExpenseViewModel()
        {
            _mySource = new Dictionary<string, DateTime>();
            Populate();
        }
        public DateTime SelectedDate
        {
            get;
            set;
        }
    }
