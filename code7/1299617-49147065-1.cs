    var person1 = new Person(Firstname = "John", Lastname = "Doe", Birthdate = new DateTime(1973, 01, 04));
    
    var person2 = new Person(Firstname = "John", Lastname = "Doe", Birthdate = new DateTime(1973, 01, 04));
    
    bool isSameContent = person1.Equals(person2);         // true
    bool isSameObject = person1.ReferenceEquals(person2); // false
    var person3 = person1;
    bool isSameObject2 = person1.ReferenceEquals(person3); // true
