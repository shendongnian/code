    var userContextOne = new EntityContext();
    var user = contexOne.Users.FirstOrDefault();
    
    var AppDbContextTwo = new EntityContext();
    
    // Warning when you work with entity properties here! Be sure that all objects came from the same context!
    db.Entry(target).State = EntityState.Modified;
    
    AppDbContextTwo.SaveChanges();
    
