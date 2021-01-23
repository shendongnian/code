    theFirstEntity = myDbContext.FirstEntity.Single(f => f.Id == Guid.Parse("5e27bfd3-d65b-4164-a0e4-93623e1b0de0"));
    theFirstEntity.SecondEntityId = Guid.Parse("C5AB5CBA-5CD8-40B7-ABFB-C22F17646D44");
    myDbContext.SaveChanges();
    
    DbContext.Entry(theFirstEntity).Reference(t => t.SecondEntity).Load();
