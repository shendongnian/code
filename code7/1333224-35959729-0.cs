    public class GlobalCompanyRepository : IGlobalCompanyRepository
    {
        private readonly string _dbConnectionString;
    
        public GlobalCompanyRepository(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
            dbContext = new IntrinsicDbContext(_dbConnectionString);
        }
    
        public IntrinsicDbContext dbContext;
        public void Add(GlobalCompany entity)
        {
            dbContext.GlobalCompanies.Add(entity);
            dbContext.SaveChanges();
        }
    }
