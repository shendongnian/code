    public PMContext() : this(true)
    { }
    
    private PMContext(bool doLogging) : base("MYEntities")
    {
        Configuration.ProxyCreationEnabled = false;
        Configuration.LazyLoadingEnabled = false;
        if (doLogging)
        {
            this.Database.Log = s => LogStore(s);
        }
    }
    private void LogStore(string message)
    {
        using(var db = new PMContext(false))
        {
            TLog log = new TLog();
            log.description = message;
            log.insertDate = DateTime.Now;
            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
