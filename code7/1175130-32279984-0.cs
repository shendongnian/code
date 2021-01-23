    public List<Person> PersonsCache;
    public List<Student> StudentsCache;
    
    using (myEntities ctx = new myEntities())
    {
         ctx.Configuration.ProxyCreationEnabled = false;
         PersonsCache = ctx.Persons
                           .AsNoTracking()
                           .ToList();
    }
    using (myEntities ctx = new myEntities())
    {
         ctx.Configuration.ProxyCreationEnabled = false;
         StudentsCache= ctx.Student
                           .AsNoTracking()
                           .ToList();
    }
    
