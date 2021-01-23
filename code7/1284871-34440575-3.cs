    public class YourClass
    {
        private readonly AsyncLazy<Data> _lazyData;
        public YourClass()
        {
            _lazyData = new AsyncLazy<Data>(() => GetData(), false);
        }
    
        private async Task<Data> GetDefaultData()
        {
           return await _lazyData.Value;
        }
        public Task<Data> GetData()
        {
            //...
        }
    }
