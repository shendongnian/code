    public List<Person> SearchPeople(string searchTerm, Expression<Func<Person, string>> selector)
    {                         
         return myDbContext.Persons
                           .AsExpandable()
                           .Where(person => selector.Invoke(person).Contains(searchTerm))
                           .ToList();                
    }
