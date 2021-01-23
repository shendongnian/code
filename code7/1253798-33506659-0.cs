    public class SortableObservableCollection<T, TSortKey> : ObservableCollection<T>
    {
        private readonly Func<T, TKey> _sortByKey;
        public SortableObservableCollection(Func<T, TKey> sortByKey)
        {
            _sortByKey = sortByKey;
        }
         
        public void Sort() {
             // slow O(n^2) sort but should be good enough because user interface rarely has milion of items
            var sortedList = Items.OrderBy(_sortByKey).ToList();
            for (int i = 0; i < sortedList.Count; ++i)
            {
                var actualItemIndex = Items.IndexOf(sortedList[i]);
                if (actualItemIndex != i)
                    Move(actualItemIndex, i);
            }
                
        }
    }
