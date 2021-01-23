    WebProxy RandomProxy
    {
        get
        {
            var proxyCount = proxies.Count;
            if (proxies.Count == 0)
            {
                return null
            }
            
            var randomIndex = rnd.Next(proxies.Count);
            var randomProxy = proxies[randomIndex];
            proxies.RemoveAt(randomIndex); // remove already used proxy
    
            return new WebProxy(randomProxy);
        }
    }
