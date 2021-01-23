    private void FillDataGridByTypeCollection()
    {
        Persons.Add(new Person() { Id = 1, Name = "Ben" });
        Persons.Add(new Person() { Id = 1, Name = "Joseph" });
        Persons.Add(new Person() { Id = 1, Name = "Jon" });
        Persons.Add(new Person() { Id = 1, Name = "Magnus Montin" });
        Persons.Add(new Person() { Id = 1, Name = "Andy" });
        Person person = Persons[1];
    }
    private ObservableCollection<Person> persons = new ObservableCollection<Person>();
    public ObservableCollection<Person> Persons
    {
       get { return persons; }
       set { persons = value; }
    }
