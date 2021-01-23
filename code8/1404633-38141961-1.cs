    var userContextOne = new MyDbContext();
    var user = userContextOne.Users.FirstOrDefault();
    
    var AppDbContextTwo = new MyDbContext();
    
    // Warning when you work with entity properties here! Be sure that all objects came from the same context!
    db.Entry(target).State = EntityState.Modified;
    
    AppDbContextTwo.SaveChanges();
    
