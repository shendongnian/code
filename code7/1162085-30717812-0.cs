    var nameLookup = new Dictionary<Tuple<string,string>, List<Person>>();
    foreach(var person in listOfPeople)
    {
        List<Person> people = null;
        var firstLast = Tuple.Create(person.fname, person.lname);
        if(nameLookup.TryGetValue(firstLast, out people))
        {
            people.Add(person);
        }
        else
        {
            nameLookup.Add(firstLast, new List<Person> { person });
        }
        var lastFirst = Tuple.Create(person.lname, person.fname);
        if(nameLookup.TryGetValue(lastFirst, out people))
        {
            people.Add(person);
        }
        else
        {
            nameLookup.Add(lastFirst, new List<Person> { person });
        }
    }
