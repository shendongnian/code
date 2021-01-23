    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class PeoplesViewModel
    {
        private ObservableCollection<Person> _people;
        private ListCollectionView _filteredPeople;
    
        public PeoplesViewModel()
        {
            _people = new ObservableCollection<Person>();
            _filteredPeople = new ListCollectionView(_people);
    
            _people.Add(new Person { FirstName = "John", LastName = "Smith" });
            _people.Add(new Person { FirstName = "David", LastName = "Smith" });
            _people.Add(new Person { FirstName = "John", LastName = "Jones" });
    
            _filteredPeople.Filter = x => ((Person) x).FirstName == "John";
        }
    
        public IEnumerable People { get { return _filteredPeople; } } 
    }
