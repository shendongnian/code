    internal class ScopeRootFactory : IScopeRootFactory
    {
        private readonly IResolutionRoot resolutionRoot;
        public ScopeRootFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
    
        public IScopeRoot CreateScopeRoot()
        {
            return this.resolutionRoot.Get<IScopeRoot>(new NamedScopeParameter("ScopeName");
        }
    }
