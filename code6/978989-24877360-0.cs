    using (DatabaseContext db = new DatabaseContext())
    {
        for (int i = 0; i < 1000000; i++)
        {
            db.Table.Add(new Row(){ /* column data goes here */});
        }
        db.SaveChanges();
    }
