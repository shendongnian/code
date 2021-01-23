    public class TenantConnectionStringProvider : ITenantConnectionStringProvider
    {
        private readonly Func<ClaimsPrincipal> _claimsPrincipalFactory;
        public TenantConnectionStringProvider(Func<ClaimsPrincipal> claimsPrincipalFactory)
        {
            _claimsPrincipalFactory = claimsPrincipalFactory;            
        }
        public void TestMethod()
        {
            // Access the current principal
            var principal = _claimsPrincipalFactory();
        }
    }
