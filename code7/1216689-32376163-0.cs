    public DbRepositoryFactory
    {    
        public IGenericRepository<User> GetUserRepository()
        {
            return ConfigurationManager.AppSettings["DbSwitch"].Equals("Azure")
                ? new GenericRepository<MyProj.Data.SqlAzure.User>()
                : new GenericRepository<MyProj.Data.SqlCe.User>()
        }
    }
