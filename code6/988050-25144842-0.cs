    using(DataContext db = new DataContext())
    {
       Child c = new Child();
       c.ForeignKeyID = SomeID;
       db.InsertOnSubmit(c);
       db.SubmitChanges();
    }
