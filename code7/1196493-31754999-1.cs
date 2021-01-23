     for (int i = 0; i < aList.Count(); i++ )
    {
        A entry = aList.ElementAt(i);
        db.A.AddOrUpdate(entry);
        // Instead of using AddOrUpdate you can use Add function
        db.Add(entry);
        
    }
    int results = db.SaveChanges();
