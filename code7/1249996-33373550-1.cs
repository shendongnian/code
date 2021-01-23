    static string conString
    {
         get
         {
             var bilde =new MySqlConnectionStringBuilder();
             builder.Server = DBServer;
             builder.UserID = UName;
             builder.Password = PWord;
             builder.Database = DBName;
             return builder.ToString();
         }
    }
