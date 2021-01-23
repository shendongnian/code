    var f = myDbContext.Set<FirstEntity>().Include(p => p.SecondEntity)
        .Single(x => x.Id == Guid.Parse("5e27bfd3-d65b-4164-a0e4-93623e1b0de0"));
    
    var s = myDbContext.Set<SecondEntity>()
        .Single(x => x.Id == Guid.Parse("C5AB5CBA-5CD8-40B7-ABFB-C22F17646D44"));
    
    f.SecondEntity = s;
    
    myDbContext.SaveChanges();
