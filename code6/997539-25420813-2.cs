    using (var db = new AppContext())
    {
        db.SetStoreConfiguration("DefaultpartnerID", 1);
        db.SaveChanges();
    }
    using (var db = new AppContext())
    {
        var defaultpartnerID = db.GetStoreConfiguration<int>("DefaultpartnerID");
        db.SaveChanges();
    }
