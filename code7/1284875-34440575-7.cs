    public class YourClass
    {
        private readonly Lazy<Data> _lazyData;
        public YourClass()
        {
            _lazyData = new Lazy<Data>(() => GetData());
        }
    
        private Data GetDefaultData()
        {
           return _lazyData.Value;
        }
        public Data GetData()
        {
            //...
        }
    }
