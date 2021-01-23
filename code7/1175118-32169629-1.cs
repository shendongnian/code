    private IEnumerable<MyClass> AllPersons;//global variable
    using (var ctx = new myEntities())
    {
         AllPersons = ctx.People
             .Select(c => new MyClass { PersonId = c.PersonId, PersonName = c.PersonName }).ToList();
    }
