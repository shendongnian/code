      public class TestBase
        {
            private TransactionScope _transactionScope;
            private GenericRepository<TipoDeCanal> _repository;
            private ComisionesContext _dataSource;
    
            private static bool _isInitialized = false;
            public TestBase()
            {
                if (!_isInitialized)
                {
                    TestClassInitialize();
                    _isInitialized = true;
                }
            }
    
            public void TestClassInitialize()
            {
                _repository = new GenericRepository<TipoDeCanal>(ConfigurationManager.ConnectionStrings["ComisionesContext"].ConnectionString);
                _dataSource = new ComisionesContext(ConfigurationManager.ConnectionStrings["ComisionesContext"].ConnectionString);
                _dataSource.Database.Delete();
                _dataSource.Database.CreateIfNotExists();
                _transactionScope = new TransactionScope();
            }
        }
