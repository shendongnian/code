      var Bob = new Person("Bob", "Belcher", "800-123-12345", 13483);
      var James = new Person("James", "Bond", "555-123-6758", 13484);
      var Clark = new Person("Clark", "Kent", "111-222-3333", 13485);
    
      // Let's print out all the persons with "Bob" first name
      var allBobs = Person.Persons
        .Where(person => person.FirstName = "Bob")
        .OrderBy(person => person.LastName);
    
      Console.Write(String.Join(Environment.NewLine, allBobs));
      // Let's find Employee number by his/her first name and ensure that there's
      // only one such a person:
     int number = Person.Persons
       .Where(person => person.FirstName = "Bob")
       .Single()
       .Select(person => person.EmployeeNumber);
 
