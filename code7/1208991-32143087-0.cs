    internal sealed class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly Func<DbContext> contextProvider;
        public EntityFrameworkUnitOfWork(Func<DbContext> contextProvider)
        {
            this.contextProvider = contextProvider;
        }
        // etc
    }
