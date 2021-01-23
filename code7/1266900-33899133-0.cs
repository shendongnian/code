    public class DatabaseHelper
    {
        private IDatabaseFactory _dbFactory;
    
        public DatabaseHelper(IDatabaseFactory factory)
        {
            _dbFactory = factory;
        }
    
        ....
    }
