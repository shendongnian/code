    class PersonViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        //if you don't care about tracking changes of collection(Add, Remove)
        //then use only List<Person> without any conversions
       public List<Person> Persons { get; set; }
    }
    
