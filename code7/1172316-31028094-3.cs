    public class ExecutiveRepository : IExecutiveRepository, IDisposable
    {
        private readonly CMSContext context;
    
        public ExecutiveRepository(IDefaultContextFactory contextFactory)
        {
            this.context = contextFactory.Create();
        }
    }
