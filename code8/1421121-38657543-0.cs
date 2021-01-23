    public object GetPerson()
    {
        // Do some stuff
        dynamic person = new ExpandoObject();
        person.Name = "Bob";
        person.Surname = "Smith";
        person.DoB = new DateTime(1980, 10, 25);
        return person;
    }
