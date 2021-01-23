     class CarDA
        {
            public const string YOUR_SPECIFIC_CACHE_KEY = "YOUR_SPECIFIC_CACHE_KEY";
            public IList<Car> Search(string searchExpression)
            {
                var carList = ListAllCars();
                //AMK: do the math and do the filter
    
                return Filtered_Car_List;
            }
    
            private IList<Car> ListAllCars()
            {
                var ExpireTime = 10;
                if (!MemoryCache.Default.Contains(YOUR_SPECIFIC_CACHE_KEY))
                {
                    MemoryCache.Default.Add(
                        new CacheItem(YOUR_SPECIFIC_CACHE_KEY, PopulateCarList()),
                        new CacheItemPolicy
                        {
                            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(ExpireTime)
                        });
                }
                return MemoryCache.Default.Get(YOUR_SPECIFIC_CACHE_KEY) as IList<Car>;
            }
    
            private IList<Car> PopulateCarList()
            {
                //AMK: fetch car list from db and create a list
                return new List<Car>();
            }
        }
    
        class Car
        {
            public string Name { get; set; }
        }
