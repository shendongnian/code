    class ZipCodeCache2 : IZipCodeService
    {
        private readonly IZipCodeService realService;
        private readonly ConcurrentDictionary<string, Task<ICollection<ZipCode>>> zipCache = new ConcurrentDictionary<string, Task<ICollection<ZipCode>>>();
        public ZipCodeCache2(IZipCodeService realService)
        {
            this.realService = realService;
        }
        public Task<ICollection<ZipCode>> GetZipCodesAsync(string cityName)
        {
            Task<ICollection<ZipCode>> zipCodes;
            if (zipCache.TryGetValue(cityName, out zipCodes))
            {
                return zipCodes;
            }
            return this.realService.GetZipCodesAsync(cityName).ContinueWith((task) =>
            {
                this.zipCache.TryAdd(cityName, task);
                return task.Result;
            });
        }
    }
