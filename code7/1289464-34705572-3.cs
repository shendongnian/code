    public class GridViewModel:BaseObservableObject
    {
      
        public GridViewModel()
        {
            var l = new List<Person>
            {
                new Person {FNAME = "John", LNAME = "W"},
                new Person {FNAME = "George", LNAME = "R"},
                new Person {FNAME = "Jimmy", LNAME = "B"},
                new Person {FNAME = "Marry", LNAME = "B"},
                new Person {FNAME = "Ayalot", LNAME = "A"},
            };
            Persons = new ObservableCollection<Person>(l);
        }
        public ObservableCollection<Person> Persons { get; set; }
    }
