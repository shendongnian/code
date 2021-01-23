    public IPerson CreatePerson(string name, IEnumerable<Persons> parents)
    {
        Person person = new Person { Name = name, Parents = parents };
        
        // Persistence stuff
    
        return person;
    }
