    public class SettingsCache<T> : ILogger where T : ICacheItem
    {
        private Dictionary<int, Dictionary<int, T>> _cachedItems;
        //...
        public SettingsCache(string connectionString, string commandText)
        {
            //...
        }
        private void AddItem(T item)
        {
            if (!_cachedItems.ContainsKey(item.PartnerId))
            {
                _cachedItems.Add(item.PartnerId, new Dictionary<int, T>());
            }
            if (_cachedItems[item.PartnerId].ContainsKey(item.Id))
            {
                _cachedItems[item.PartnerId].Remove(item.Id);
            }
            _cachedItems[item.PartnerId].Add(item.Id, item);
        }
    }
