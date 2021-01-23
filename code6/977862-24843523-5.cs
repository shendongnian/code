    public static class ListHelper
    {
        public static int BinarySearchFirst<T>(this List<T> list, T item, IComparer<T> comparer)
        {
            int index;
            for (index = list.BinarySearch(item, comparer); index > 0; index--)
            {
                if (comparer.Compare(list[index], list[index - 1]) != 0)
                    return index;
            }
            return index;
        }
    }
