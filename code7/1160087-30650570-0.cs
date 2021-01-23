    var randomRecords = new List<TableName>();
    foreach(int id in randIds)
    {
        var match = db.DbSet<TableName>().Find(id);
        //if the id is not present, then you can iterate a little to find it
        while(match != null)
        {
            match = db.DbSet<TableName>().Find(++id);
        }
        randomRecords.Add(match);
    } 
