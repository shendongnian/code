    public class UnitOfWork
    {
        public DbSet<Company> Companies { get; set; }
    
        public int SaveChanges()
        {
            underlyingContext.SaveChanges();
        }
    }
    
    public class UnitOfWorkFactory
    {
        public UnitOfWork Create() 
        {
            // real creation logic
            return new UnitOfWork();
        }
    }
    
    public class CompanyRepository
    {
        private readonly UnitOfWork uow;
    
        public CompanyRepository(UnitOfWork uow)
        {
            uow = uow;
        }
    
        public void Add(Company company)
        {
            uow.Companies.Add(company);
        }  
    }
    
    public class CompanyRepositoryFactory
    {
        public Create(UnitOfWork uow)
        {
            new CompanyRepository(uow);
        }
    }
