        public RelayCommand<int> FilterAgeCommand { get; set; }
        public Base_ViewModel()
        {
            FilterAgeCommand = new RelayCommand<int>(OnFilterAgeCommand);
            this.TestClassList = new ObservableCollection<TestClass>();
            this.TestClassList.Add(new TestClass() { FName = "John", SName = "Doe", Age = 25 });
            this.TestClassList.Add(new TestClass() { FName = "Jane", SName = "Doe", Age = 75 });
            this.TestClassList.Add(new TestClass() { FName = "Mick", SName = "Doe", Age = 35 });
            this.TestClassList.Add(new TestClass() { FName = "Harry", SName = "Doe", Age = 10 });
            this.TestClassList.Add(new TestClass() { FName = "Linda", SName = "Doe", Age = 25 });
            this.TestClassList.Add(new TestClass() { FName = "Fred", SName = "Doe", Age = 14 });
            this.FilteredTestClassList = new ObservableCollection<TestClass>();
            this.Age = new List<int>();
            for(int i = 1; i <100; i++)
            {
                this.Age.Add(i);
            }
        }
        private void OnFilterAgeCommand(int obj)
        {
            this.FilteredTestClassList = Convert<TestClass>((from tc in this.TestClassList where tc.Age < obj select tc).ToList());
        }
        public List<int> Age { get; set; }
        public ObservableCollection<TestClass> TestClassList { get; set; }
        private ObservableCollection<TestClass> _FilteredTestClassList;
        public ObservableCollection<TestClass> FilteredTestClassList 
        {
            get { return _FilteredTestClassList; }
            set { _FilteredTestClassList = value; OnPropertyChanged("FilteredTestClassList"); }
        }
        public ObservableCollection<T> Convert<T>(IEnumerable original)
        {
            return new ObservableCollection<T>(original.Cast<T>());
        }
