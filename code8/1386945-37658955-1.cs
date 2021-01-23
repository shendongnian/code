    public static List<T> GetListItemRange<T>(string key, int start, int chunksize) where T : class
            {
                List<T> obj = default(List<T>);
                try
                {
                    if (Muxer != null && Muxer.IsConnected && Muxer.GetDatabase() != null)
                    {
                        var cacheClient = new StackExchangeRedisCacheClient(Muxer, new NewtonsoftSerializer());
                        var redisValues = cacheClient.Database.ListRange(key, start, (start + chunksize - 1));
                        if (redisValues.Length > 0)
                        {
                            obj = Array.ConvertAll(redisValues, value => JsonConvert.DeserializeObject<T>(value)).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Fatal(ex.Message, ex);
                }
                return obj;
            }
