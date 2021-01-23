    public class SomeService
    {
        private ApplicationDbContext MyDbContext { get; set; }
        public SomeService(ApplicationDbContext dbContext)
        {
           MyDbContext = dbContext;
        }
        public void MethodName()
        {
            // You can now do MyDbContext.SomeDomainModel
        }
    }
