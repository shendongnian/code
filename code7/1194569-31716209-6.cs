    class Program
    {
        static void Main(string[] args)
        {
            // Configure databases from some external source but ensure that 
            // database name matches XML config
            DatabaseFactory.SetDatabases(
                () => CreateDatabaseFromExternalSource(null),
                name => CreateDatabaseFromExternalSource(name));
            // Configure logging from XML config 
            LogWriterFactory factory = new LogWriterFactory();
            Logger.SetLogWriter(factory.Create());
            Logger.Write("Test", "General");
        }
        private static Database CreateDatabaseFromExternalSource(string name)
        {
            // SqlDatabase assumes SQL Server database
            return new SqlDatabase(GetConnectionString(name));
        }
        private static string GetConnectionString(string name)
        {
            // do whatever you need to get the database connection
            return @"Server=.\SQLEXPRESS;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        }
    }
