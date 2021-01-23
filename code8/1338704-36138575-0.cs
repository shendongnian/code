    Person person1 = new Person("Bob","McGee",1992,"M");
    Person person2 = new Person("Gilbert", 1984, "M");
    Person persone = new Person("hank" 1989, "F");
    List<Person> list = new List<Person>();
    list.Add(person1);
    list.Add(person2);
    list.Add(persone);
    Person person = FindPersonByYear(list, 1989);
    string message;
    if(person != null)
        message = Person.name + " is " + (DateTime.Now.Year - person.year).TotalYears + " years old.";
    else
        message = "Could not find anyone";
    MessageBox.Show(message);
