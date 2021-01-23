    public static class ObservableCollectionExtensions
    {
        public static void MatchSort<T>(this ObservableCollection<T> collection, IEnumerable<T> collectionToMatchSortOrder)
        {
            int newIndex = 0;
    
            foreach (var item in collectionToMapSortOrder.Where(item => collection.Contains(item)))
            {
                collection.Move(collection.IndexOf(item), newIndex);
                newIndex++;
            }
        }
    }
