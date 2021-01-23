    interface IRepository<TItem, TKey>
    {
        void RemoveItem(TItem item);
        void RemoveByKey(TKey key);
        void RemoveByName(string name);
    }
