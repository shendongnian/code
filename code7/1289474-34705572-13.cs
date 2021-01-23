    //inside your code behind
        public static readonly DependencyProperty PersonsCollectionProperty = DependencyProperty.Register(
            "PersonsCollection",
            typeof (ObservableCollection<Person>),
            typeof (AlgorithmEditorDialogLauncherViewModel),
            new PropertyMetadata(default(ObservableCollection<Person>)));
        public ObservableCollection<Person> PersonsCollection
        {
            get { return (ObservableCollection<Person>) GetValue(PersonsCollectionProperty); }
            set { SetValue(PersonsCollectionProperty, value); }
        }
        //inside the c'tor of your code behind
        var l = new List<Person>
        {
            new Person {FNAME = "John", LNAME = "W"},
            new Person {FNAME = "George", LNAME = "R"},
            new Person {FNAME = "Jimmy", LNAME = "B"},
            new Person {FNAME = "Marry", LNAME = "B"},
            new Person {FNAME = "Ayalot", LNAME = "A"},
        };
        PersonsCollection = new ObservableCollection<Person>(l);
