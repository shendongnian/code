    // assume these properties are part of DB provider definition
    public class DatabaseSettings 
    {
        public String ConnectionName { get; set; }
        public String ServerName { get; set; }
        public String DatabaseName { get; set; }
        public String UserId { get; set; }
        public String Password { get; set; }
    }
    // controller method definition
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    
    builder.DataSource = DatabaseSettings.ServerName;
    builder.InitialCatalog = DatabaseSettings.DatabaseName;
    builder.IntegratedSecurity = true;
    builder.UserID = DatabaseSettings.UserId;
    builder.Password = DatabaseSettings.Password;
    builder.MultipleActiveResultSets = true;
    // modify initial connection string in runtime
    // note that ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString is readonly by default, 
    // thus use reflection to disable private bReadOnly field before adding custom connection string
    var connectionString = ConfigurationManager.ConnectionStrings;
    var collection = typeof(ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    collection.SetValue(connectionString, false);
    // This one may work if you tend to change default connection string value
    // connectionString[0].ConnectionString = builder.ToString();
    // Safer way by adding new name rather than replace default one
    connectionString.Add(new ConnectionStringSettings(DatabaseSettings.ConnectionName, builder.ToString()));
