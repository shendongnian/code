    // this is what you know, creating persons.
    Person person1 = new Person("Bob","McGee",1992,"M"); // <---- NOTE?   four parameters????  (you code would not compile....)
    Person person2 = new Person("Gilbert", 1984, "M");
    Person persone = new Person("hank" 1989, "F");
    // create a list that contains Persons
    List<Person> list = new List<Person>();
    // add those persons to the list.
    list.Add(person1);
    list.Add(person2);
    list.Add(persone);
    // with the FirstOrDefault() extension method you can select a person.
    Person person = personList.FirstOrDefault(item => item.year == year);
    // create a message
    string message;
    // check if the person is a valid instance, because FirstOrDefault will return the default(Person) if none of the persons mathes the criteria. (default == null)
    if(person != null)
        message = Person.name + " is " + (DateTime.Now.Year - person.year).TotalYears + " years old.";
    else
        message = "Could not find anyone";
    // show the message.
    MessageBox.Show(message);
