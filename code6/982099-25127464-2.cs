    public class SortedCollection<T> : ObservableCollection<T> where T : IComparable<T>
    {
        protected override void InsertItem(int index, T item)
        {
            int sortedIndex = FindSortedIndex(item);
            base.InsertItem(sortedIndex, item);
        }
        private int FindSortedIndex(T item)
        {
            //simple sorting algorithm
            for (int index = 0; index < this.Count; index++)
            {
                if (item.CompareTo(this[index]) > 0)
                {
                    return index;
                }
            }
            return 0;
        }
    }  
