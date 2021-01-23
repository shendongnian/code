    var db = new YourContext();
    var cat= new Cat(){Name="New Cat"};
    db.Set<Cate>().Add(cat);
    db.SaveChanges();
    // Here it will use inserted cat Id
    // MessageBox.Show(cat.Id.ToString());
    db.Set<Log>().Add(new Log {EntityId = cat.Id, EntityType = 1}); 
