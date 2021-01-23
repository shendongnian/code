    class ExpenseViewModel : INotifyPropertyChanged, IDataErrorInfo
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
        private void populate()
        {
            _totalPeople.Add(2);
            _totalPeople.Add(3);
            _totalPeople.Add(4);
            _totalPeople.Add(5);
            NotifyPropertyChanged("TotalPeople");
        }
        private List<int> _totalPeople;
        public IEnumerable<int> TotalPeople
        {
            get { return _totalPeople; }
        }
        public ExpenseViewModel()
        {
            _totalPeople = new List<int>();
            populate();
        }
        public int SelectedIndex { get; set; }
        private string _error;
        public string Error
        {
            get { return _error; }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName.Equals("SelectedIndex"))
                {
                   if(SelectedIndex==0)
                   {
                       _error = "Please Select One";
                   }
                }
                return Error;
            }
        }
    }
