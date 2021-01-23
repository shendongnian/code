    //get the list of bad guys
    List<Person> badGuys = ...
    //get simple primitive type enumeration
    var badGuysIDs = badGuys.Select(t => t.PersonId).ToList();
    using(Context c = new Context())
    {
       var badPersons = c.Persons.Where(t => !badGuysIDs.Contains(t.PersonId)).ToList();
    }
