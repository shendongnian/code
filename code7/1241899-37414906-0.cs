        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public virtual T Get<T>(string key)
        {
            //little performance workaround here:
            //we use "MemoryCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server 500 times per HTTP request (e.g. each time to load a locale or setting)
            if (_memoryCacheManager.IsSet(key))
                return _memoryCacheManager.Get<T>(key);
            var rValue = _db.StringGet(key);
            if (!rValue.HasValue)
                return default(T);
            var result = Deserialize<T>(rValue);
            _memoryCacheManager.Set(key, result, CacheProfiles.ShortLivedDuration);
            return result;
        }
        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null || string.IsNullOrEmpty(key))
                return;
            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);
             _db.StringSetAsync(key, entryBytes, expiresIn);
            _memoryCacheManager.Set(key, data, cacheTime);
        }
