    public object Get(string key)
    {
        return Deserialize(Cache.StringGet(key));
    }
    
    public object GetWithRetry(string key, int wait, int retryCount)
    {
        int i = 0;
        do
        {
            try
            {
                return Get(key);
            }
            catch (Exception)
            {
                if (i < retryCount + 1)
                {
                    Thread.Sleep(wait);
                    i++;
                }
                else throw;
            }
        }
        while (i < retryCount + 1);
        return null;
    }
