    public CarsHelper()
    {
        db = new ProjectEntities();
        db.Database.Connection.ConnectionString ="Your Connection String";
    }
