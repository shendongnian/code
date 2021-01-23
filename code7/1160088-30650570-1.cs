    var randomRecords = new List<TableName>();
    foreach(int id in randIds)
    {
        var match = db.DbSet<TableName>().Find(id);
        //if the id is not present, then you can iterate a little to find it
        //or provide a custom column for the exact record as you indicate in comments
        while(match != null)
        {
            match = db.DbSet<TableName>().Find(++id);
        }
        randomRecords.Add(match);
    } 
