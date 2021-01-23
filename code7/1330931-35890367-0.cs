    public class Cache
    {
        private object _locker = new object();
        private SessionDataCollection _cache;
        public SessionData Get(SessionId id)
        {
            lock (_locker)
            {
                if (!Contains(id))
                    Fetch(id);
                return Retrieve(id);
            }
        }
        private bool Contains(SessionId id)
        {
            //check if present in _cache
        }
        private void Fetch(SessionId id)
        {
            //get from db and store in _cache
        }
        private SessionData Retrieve(SessionId id)
        {
            //retrvieve from _cache
        }
    }
