    public class LockStore
    {
        private readonly Dictionary<string, StoredLock> m_Dictionary =
            new Dictionary<string, StoredLock>();
        public void UseResource(string resource_id, Action<StoredLock> action)
        {
            StoredLock stored_lock = null;
            lock(m_Dictionary)
            {
                if (m_Dictionary.ContainsKey(resource_id))
                {
                    stored_lock = m_Dictionary[resource_id];
                }
                else
                {
                    stored_lock = new StoredLock
                    {
                        Id = resource_id,
                        CreatedDateTime = DateTime.Now
                    };
                    m_Dictionary.Add(resource_id,stored_lock);
                }
            }
            lock(stored_lock)
            {
                action(stored_lock);
            }
        }
        public bool RemoveLock(string resource_id)
        {
            lock (m_Dictionary)
            {
                if (!m_Dictionary.ContainsKey(resource_id))
                    return true;
                var stored_lock = m_Dictionary[resource_id];
                bool taken = false;
                Monitor.TryEnter(stored_lock, ref taken);
                if (!taken)
                    return false;
                try
                {
                    m_Dictionary.Remove(resource_id);
                }
                finally
                {
                    Monitor.Exit(stored_lock);
                }
                return true;
            }
        }
    }
