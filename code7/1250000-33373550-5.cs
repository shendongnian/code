    private MySqlConnection CreateConnection()
    {
         var builder = new MySqlConnectionStringBuilder();
         builder.Server = Properties.Settings.Default.DBServer,
         builder.UserID = Properties.Settings.Default.UName,
         builder.Password = Properties.Settings.Default.PWord, 
         builder.Database = Properties.Settings.Default.DBName
         return new MySqlConnection(builder.ToString());
    }
