    db.Database.Log = s =>
    {
        // You can put a breakpoint here and examine s with the TextVisualizer
        // Note that only some of the s values are SQL statements
        Debug.Print(s);
    };
    db.SaveChanges();
