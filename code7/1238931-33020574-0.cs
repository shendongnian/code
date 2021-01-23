    public Dictionary<Guid, ApiUser> UserNamesByToken
        {
            get
            {
                return _cacheProvider.Get(CacheKey, () => _apiUsers.Where(u => u.IsActive).ToDictionary(u => u.Token, u => u));
            }
        }
