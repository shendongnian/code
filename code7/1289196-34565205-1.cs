    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> Range(this ObservableCollection<T> sequence, int start, int count)
        {
             return new ObservableCollection(sequence.Skip(start).Take(count));
        }
    }
