    public class PerOperationThrottle: IInstanceContextInitializer
    {
        static MemoryCache cache = new MemoryCache("foo", null);
    
        public void Initialize(InstanceContext instanceContext, Message message)
        {
            RemoteEndpointMessageProperty  ep = message.Properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            // which action do we want to throttle
            if (message.Headers.Action.EndsWith("register") &&
                ep != null && 
                ep.Address != null)
            {
                // get the IP address 
                var item = cache[ep.Address];
                if (item == null)
                {
                    // not found, so init
                    cache.Add(
                        ep.Address,
                        new Counter { Count = 0 },
                        new CacheItemPolicy
                        {
                            SlidingExpiration = new TimeSpan(0, 1, 0) // 1 minute
                        });
                }
                else
                {
                    // how many calls?
                    var count = (Counter)item;
                    if (count.Count > 5)
                    {
                        instanceContext.Abort();
                        // not sure if this the best way to break
                        throw new Exception("throttle");
                    }
                    // add one call
                    count.Count++;
                }
            }
        }
    }
