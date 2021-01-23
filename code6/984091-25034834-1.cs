    public class DataServiceFactory : IDataServiceFactory
    {
        private readonly Func<IDataService> _sqlDataServiceFactory;
        private readonly Func<IDataService> _oracleDataServiceFactory;
    
        public DataServiceFactory(Func<IDataService> sqlDataServiceFactory, Func<IDataService> oracleDataServiceFactory)
        {
            _sqlDataServiceFactory = sqlDataServiceFactory;
            _oracleDataServiceFactory = oracleDataServiceFactory;
        }
        public IDataService CreateSqlDataService()
        {
            return _sqlDataServiceFactory();
        }
        public IDataService CreateOracleDataService()
        {
            return _oracleDataServiceFactory();
        }
    }
