    Class DataAccess
    {
        private readonly string _dbLocation;
        public DataAccess(string dbLocation)
        {
            _dbLocation = dbLocation;
        }
        public SomeType GetData()
        {
            // use _dbLocation to access DB
        }
    }
