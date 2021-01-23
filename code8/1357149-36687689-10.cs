    public class RequestRepository
    {
        private IDbContextFactory _contextFactory;
        public RequestRepository(IDbContextFactory contextFactory)
        {
            // DbContext will not be created in constructor, and therefore your repository doesn't have to implement IDisposable.
            _contextFactory= contextFactory;
        }
        public Request FindById(int id)
        {
             // Context will be properly disposed thanks to using.
            using (var context = _dbContextFactory.GenerateContext())
            {
                return context.Requests.FirstOrDefault(x => x.Id == id);
            }
        }
    }
