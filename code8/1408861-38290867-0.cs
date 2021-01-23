     public bool Remove(TValue item)
     {
        lock (item) // this should be _lock
        {
            return _storage.Remove(item);
        }
     }
