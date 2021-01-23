    dynamic person = new ExpandoObject();
    person.Name = "Matt";
    person.Surname = "Smith";
    
    object value = myFunc(person);
    Console.WriteLine(value); //Will print out "Matt Smith"
    //Internally it just calls:
    //string.Concat(new object[] { person.Name, " ", person.Surname });
