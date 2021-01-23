    // Using LINQ and just referencing p.Employer will lazy load
    // I am not at a computer but I know I have lazy loaded in one
    // query with a single query call like below.
    List<Person> persons = new List<Person>();
    using(MyDbContext dbContext = new MyDbContext())
    {
        persons = (
            from p in dbcontext.Persons
            select new Person{
                Name = p.Name,
                Email = p.Email,
                Employer = p.Employer
            }).ToList();
    }
