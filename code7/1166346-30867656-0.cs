    public interface IMigrationService
    {
    	Task RunMigrations();
    }
    public interface IMigration
    {
    	IMigration UseConnection(SQLiteAsyncConnection connection);
    	Task<bool> Run();
    }
