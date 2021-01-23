    public class TestLoader : ILoader
    {
        private IEnumerable<int> _Datasource;
        public TestLoader(IEnumerable<int> enumerable)
        {
            _Datasource = enumerable;
        }
        public IEnumerable<int> Get()
        {
            return _Datasource;
        }
    }
