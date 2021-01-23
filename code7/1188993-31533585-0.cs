    class ClassTest : INotifyPropertyChanged
    {
        private IEnumerable<Day> myList;
        public IEnumerable<Day> MyList
        {
            get { return myList; }
            set
            {
                if (value != myList)
                {
                    myList= value;
                    OnPropertyChanged("MyList");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
