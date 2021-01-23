    public static bool InsertListItemRange<T>(string key, List<T> obj, int chunksize = 25000) where T : class
            {
                bool result = false;
                try
                {
                    if (Muxer != null && Muxer.IsConnected && Muxer.GetDatabase() != null)
                    {
                        var cacheClient = new StackExchangeRedisCacheClient(Muxer, new NewtonsoftSerializer());
    
                        List<RedisValue> lst  = new List<RedisValue>();
    
                        foreach (var o in obj)
                        {
                           lst.Add(JsonConvert.SerializeObject(o));   
                        }
    
    
                        result = cacheClient.Database.ListLeftPush(key, lst.ToArray()) > 0;
    
    
                        if (LogRedisRelatedActivities)
                        {
                            Logger.InfoFormat("InsertItem => Key: {0}, Result: {1}", key, result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Fatal(ex.Message, ex);
                }
                return result;
            }
