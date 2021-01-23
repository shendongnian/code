    string connectionString
            = "Data Source=(LocalDB)\\v11.0;AttachDbFilename="
            + fileSpec;
    EventsListDBEntities ctx = new EventsListDBEntities();
    ctx.Database.Connection.ConnectionString = connectionString;
    ctx.Database.CreateIfNotExists(); // Change this line.
    ctx.Database.Initialize(true);
