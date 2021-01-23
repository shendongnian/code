    ObservableCollection<Person> collPerson = new ObservableCollection<Person>();
    collPerson.Add(new Person() { IdPerson=1, FirstName="Bill"});
    collPerson.Add(new Person() { IdPerson = 2, FirstName = "Jon" });
    collPerson.Add(new Person() { IdPerson = 3, FirstName = "Joseph" });
    collPerson.Add(new Person() { IdPerson = 4, FirstName = "Ben" });
    collPerson.Add(new Person() { IdPerson = 5, FirstName = "Magnus" });
    collPerson = new ObservableCollection<Person>(collPerson.OrderBy(x=>x.FirstName));
