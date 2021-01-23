    var persons = context.GetPersonByID(personID).Select(p => new Model.Person
    {
        Name = p.Name,
        Age p.Age,
        ... etc ...
    });
    return persons.SingleOrDefault();
