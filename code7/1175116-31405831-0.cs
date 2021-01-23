    using (var ctx = new myEntities)
    {
        ctx.Configuration.ProxyCreationEnabled = false;
        ctx.Configuration.LazyLoadingEnabled = false;
        AllPersons= ctx.Persons.ToList();
        foreach(var c in AllPersons)
        {
            ctx.Detach(c);
        }
        AllStudents = ctx.Student.ToList();
        foreach(var c in AllStudents )
        {
            ctx.Detach(c);
        }
    }
