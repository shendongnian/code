    public bool Locked
    {
        get
        {
            return Database.SqlQuery<bool>("SELECT * FROM __Lock").SingleAsync().Result;
        }
        set
        {
            if (value)
                Database.ExecuteSqlCommand("UPDATE __Lock SET Lock = 1");
            else
                Database.ExecuteSqlCommand("UPDATE __Lock SET Lock = 0");
        }
    }
