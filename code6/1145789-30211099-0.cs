    public class Package
    {
        private readonly Lazy<List<Policy>> _lazyPolicies =  ...
    
        public List<Policy> Policies
        {
            get { return _lazyPolicies.Value; }
        }
    }
