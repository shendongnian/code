    public static class ObservableCollectionExtensions
    {
        public static int Remove<T>(
            this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();
    
            foreach (var item in itemsToRemove)
            {
                coll.Remove(item);
            }
    
            return itemsToRemove.Count;
        }
    }
