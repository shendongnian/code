    interface IRepository<TItem, TKey>
    {
        void Remove(TItem item);
        void Remove(TKey key);
        void Remove(string name);
    }
