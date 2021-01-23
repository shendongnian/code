    public class YourClass
    {
        private readonly AsyncLazy<Data> _lazyData;
        public YourClass()
        {
            _lazyData = new AsyncLazy<Data>(() => GetData(), false);
        }
    
        private async Task<Data> GetDefaultData()
        {
           //I await here to defer any exceptions till the returned task is awaited.
           return await _lazyData;
        }
        public Task<Data> GetData()
        {
            //...
        }
    }
