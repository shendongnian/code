    static string conString
    {
         get
         {
             var builder = new MySqlConnectionStringBuilder();
             builder.Server = DBServer;
             builder.UserID = UName;
             builder.Password = PWord;
             builder.Database = DBName;
             return builder.ToString();
         }
    }
