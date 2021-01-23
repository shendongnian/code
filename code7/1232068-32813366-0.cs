    public void insert(object data)
    {
        var db = new TestDbEntities();
        db.Set(data.GetType()).Add(data);
    }
