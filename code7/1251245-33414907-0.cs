    var db = new MyDbContext();
    db.Configuration.LazyLoadingEnabled = false;
            
    var parents = db.Parents.ToList();
    //Shows False, So childs are not loaded.
    Console.WriteLine(parents.Any(x => x.Childs.Count() > 0).ToString());
    var childs = db.Childs.ToList();
    //Shows True, We didn't loads Parents again, and EF only relates them.
    Console.WriteLine(parents.Any(x => x.Childs.Count() > 0).ToString());
