    public void Save(List<Person> people)
    {
        people.Encrypt();
        
        foreach(var person in people){
            person.Purchase = null;
        }
        Context.Person.AddRange(people);
        Context.SaveChanges();
    }
