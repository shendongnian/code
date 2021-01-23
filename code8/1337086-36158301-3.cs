    class ZipCodeCache : IZipCodeService
    {
        private readonly IZipCodeService realService;
        private readonly ConcurrentDictionary<string, ICollection<ZipCode>> zipCache = new ConcurrentDictionary<string, ICollection<ZipCode>>();
        public ZipCodeCache(IZipCodeService realService)
        {
            this.realService = realService;
        }
        public Task<ICollection<ZipCode>> GetZipCodesAsync(string cityName)
        {
            ICollection<ZipCode> zipCodes;
            if (zipCache.TryGetValue(cityName, out zipCodes))
            {
                // Already in cache. Returning cached value
                return Task.FromResult(zipCodes);
            }
            return this.realService.GetZipCodesAsync(cityName).ContinueWith((task) =>
            {
                this.zipCache.TryAdd(cityName, task.Result);
                return task.Result;
            });
        }
    }
    
