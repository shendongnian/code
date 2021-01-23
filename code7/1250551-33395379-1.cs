    public class MainViewModel : INotifyPropertyChanged
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Val { get; set; }
        }
        private object _selectedPerson;
        public object SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _isItemSelected;
        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set
            {
                if (value == _isItemSelected) 
                    return;
                _isItemSelected = value;
                OnPropertyChanged("IsItemSelected");
            }
        }
        private ObservableCollection<Person> _coll1;
        public ObservableCollection<Person> Coll1
        {
            get
            {
                return _coll1 ?? (_coll1 = new ObservableCollection<Person>());
            }
        }
        private ObservableCollection<Person> _coll2;
        public ObservableCollection<Person> Coll2
        {
            get
            {
                return _coll2 ?? (_coll2 = new ObservableCollection<Person>());
            }
        } 
        public MainViewModel()
        {
            Coll1.Add(
            new Person
            {
                FirstName = "TOUMI",
                LastName = "Redhouane",
                Val = 12.2f
            });
            Coll1.Add(
            new Person
            {
                FirstName = "CHERCHALI",
                LastName = "Karim",
                Val = 15.3f
            });
            Coll2.Add(
            new Person
            {
                FirstName = "TOUMI",
                LastName = "Djamel",
                Val = 12.2f
            });
            Coll2.Add(
            new Person
            {
                FirstName = "CHERCHALI",
                LastName = "Redha",
                Val = 12.2f
            });
        }
        
    }
