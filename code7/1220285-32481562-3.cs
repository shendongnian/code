    var peopleId = //Get Id of document to be updated.
    var persons = new List<Person>(3);
    persons.Add(new Person { name = "john", eyes = "blue", age = "27" });
    persons.Add(new Person { name = "mary", eyes = "green", age = "19" });
    persons.Add(new Person { name = "jane", eyes = "grey", age = "30" });
    
    var response = Client.Update<People, object>(u => u
                .Id(peopleId)
                .Doc(new { person = persons})
                .Refresh()
            );
