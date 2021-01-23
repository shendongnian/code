    public static class Extensions
    {
        public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector)
        {
            List<TSource> sorted = collection.OrderBy(keySelector).ToList();
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
        public static void AddSort(this ObservableCollection<MyViewModel> collection, MyViewModel newItem)
        {
            var index = collection.Where(x => x.SortOrder) < newItem.SortOrder)).Count();
            collection.Insert(index, newItem);
        }
    }
