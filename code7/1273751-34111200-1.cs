    public static class CollectionUtility
    {
        public static ObservableCollection<T> ToObservableCollection<T>(
            this IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }
    }
