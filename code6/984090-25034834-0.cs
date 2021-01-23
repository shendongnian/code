    public interface IDataServiceFactory
    {
        IDataService CreateSqlDataService();
        IDataService CreateOracleDataService();
    }
