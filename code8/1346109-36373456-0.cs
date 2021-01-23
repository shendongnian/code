    class DbContextProvider : IDbContextProvider {
        private readonly Func<DbContext> provider;
        public DbContextProvider(Func<DbContext> provider) { this.provider = provider; }
        public DbContext Context { get { return this.provider(); } }
    }
    
