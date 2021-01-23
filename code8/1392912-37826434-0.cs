     public static RedisResult PopListItemRange(int chunksize, string key)
            {
                RedisResult valreturn = null;
                try
                {
    
                    IDatabase db;
                    if (Muxer != null && Muxer.IsConnected && (db = Muxer.GetDatabase()) != null)
                    {
                        valreturn = db.ScriptEvaluate(@" local result = redis.call('lrange',KEYS[1],ARGV[1], '-1')
                                                              redis.call('ltrim',KEYS[1],'0',ARGV[2])
                                        return result", new RedisKey[] { key }, flags: CommandFlags.HighPriority, values: new RedisValue[] { -chunksize, -chunksize - 1 });
                    }
    
                }
                catch (Exception ex)
                {
                    Logger.Fatal(ex.Message, ex);
                }
                return valreturn;
            }
