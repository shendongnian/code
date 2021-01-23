    Entity1 entity1 = new Entity1()
    {
       Field = "a field"
    };
    
    var entity2 = new Entity2() 
    {
       Field = "another field"
    };
    entity1.Entity2.Add(entity2);
    var entity3 = new Entity3() 
    {
       Field = "another field"
    };
    entity2.Entity3.Add(entity3);
    var entity4 = new Entity4() 
    {
       Field = "another field"
    };
    entity3.Entity4.Add(entity4);
    using (var context = new backendEntities())
    {
        context.Entity1.Add(entity1);
        context.SaveChanges();
    }
