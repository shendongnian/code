    public class TestClass
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
    
        public TestClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    
        public void SetString()
        {
            _session.SetString("Test", "Ben Rules!");
        }
    
        public string GetString()
        {
            return _session.GetString("Test");
        }
    }
