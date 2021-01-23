    public static IDatabase GetDatabase(dataBases db)
    { 
        IDatabase d = null;
        switch(db)
        {
             case databases.db1:
                  d = new Database1();
             case databases.db2:
                  d = new Database2();
             //add new cases for each enum value
             default:
                   break;
        }
        return d;
    }
