    public static class DatabaseFactory{
         public static IDatabase GetDatabase(string dbName){
             switch(dbName){
                 case "sqlserver":
                    return new SqlServerDB();
                 case "mysql":
                    return new MySqlDB();
                 default:
                     throw new ArgumentException("Don't know about that DB");
             }
         }
    }
