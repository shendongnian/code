    public static class ObservableCollectionExtensions
    {
        public static void MergeSortedListIntoSortedObservableCollection<T>(this ObservableCollection<T> destination, IList<T> list, Func<T, T, int> compareFunc)
        {
            int dest_index = 0;
            int list_index = 0;
            while (list_index < list.Count)
            {
                if (dest_index >= destination.Count)
                {
                    destination.Add(list[list_index]);
                    list_index++;
                    dest_index++;
                }
                else
                {
                    if (compareFunc(destination[dest_index], list[list_index]) > 0)
                    {
                        destination.Insert(dest_index, list[list_index]);
                        list_index++;
                        dest_index++;
                    }
                    else
                    {
                        dest_index++;
                    }
                }
            }
        }
    }
