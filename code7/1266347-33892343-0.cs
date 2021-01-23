    public class CacheOrderRepo : IOrderRepository
    {
        private readonly IEnumerable<IOrderRepository> realTimeRepos;
        private readonly LocalOrderRepo localRepo;
        public CacheOrderRepo(IEnumerable<IOrderRepository> realTime, LocalOrderRepo localRepo)
        {
            this.realTimeRepos = realTime;
            this.localRepo = localRepo;
        }
