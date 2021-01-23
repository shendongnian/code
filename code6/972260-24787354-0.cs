        protected void Application_Start()
        {
            // ...
            AddTask("HubInactivity", 120);
        }
        private void AddTask(string name, int seconds)
        {
            OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
            HttpRuntime.Cache.Insert(name, seconds, null,
                DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }
        public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
        {
            if (k == "HubInactivity")
            {
                var time = DateTime.Now;
                // HubHelpers is where I kept the dictionary in my case
                foreach (var identity in Hubs.HubHelpers.LastConnectionTime.Keys)
                {
                    var lastConnection = Hubs.HubHelpers.LastConnectionTime[identity];
                    if ((time - lastConnection).TotalMinutes > 30.0)
                    {
                        // Do stuff.
                    }
                }
            }
            // re-add our task so it recurs
            AddTask(k, Convert.ToInt32(v));
        }
