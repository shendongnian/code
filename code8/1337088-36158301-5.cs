        public async Task<ICollection<ZipCode>> GetZipCodesAsync(string cityName)
        {
            Task<ICollection<ZipCode>> zipCodes;
            if (zipCache.TryGetValue(cityName, out zipCodes))
            {
                return zipCodes;
            }
