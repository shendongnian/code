    public void Save(List<Person> people)
    {
        people.Encrypt();
        
        foreach(var person in people){
            Context.Phones.Attach(person.Purchase)
        }
        Context.Person.AddRange(people);
        Context.SaveChanges();
    }
