    public static class ListHelper
    {
        public static int BinarySearchFirst<T>(this IList<T> list, T item, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            int start = list.BinarySearch(item, comparer);
            for (; start > 0 && comparer.Compare(list[start], list[start - 1]) == 0; start--)
                ;
            return start;
        }
        public static int BinarySearchLast<T>(this IList<T> list, T item, IComparer<T> comparer)
        {
            comparer = comparer ?? Comparer<T>.Default;
            int start = list.BinarySearch(item, comparer);
            if (start > 0)
            {
                for (int end = list.Count - 1; start < end && comparer.Compare(list[start], list[start + 1]) == 0; start++)
                    ;
            }
            return start;
        }
        
        public static int BinarySearch<T>(this IList<T> list, T value)
        {
            return BinarySearch(list, value, null);
        }
        // Searches the list for a given element using a binary search
        // algorithm. Elements of the list are compared to the search value using
        // the given IComparer interface. If comparer is null, elements of
        // the list are compared to the search value using the IComparable
        // interface, which in that case must be implemented by all elements of the
        // list and the given search value. This method assumes that the given
        // section of the list is already sorted; if this is not the case, the
        // result will be incorrect.
        //
        // The method returns the index of the given value in the list. If the
        // list does not contain the given value, the method returns a negative
        // integer. The bitwise complement operator (~) can be applied to a
        // negative result to produce the index of the first element (if any) that
        // is larger than the given search value. This is also the index at which
        // the search value should be inserted into the list in order for the list
        // to remain sorted.
        public static int BinarySearch<T>(this IList<T> list, T value, IComparer<T> comparer)
        {
            // Adapted from http://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs
            if (list == null)
                throw new ArgumentNullException("list");
            comparer = comparer ?? Comparer<T>.Default;
            int lo = 0;
            int hi = list.Count - 1;
            while (lo <= hi)
            {
                int i = lo + ((hi - lo) >> 1);
                int order = comparer.Compare(list[i], value);
                if (order == 0)
                    return i;
                if (order < 0)
                {
                    lo = i + 1;
                }
                else
                {
                    hi = i - 1;
                }
            }
            return ~lo;
        }
        public static int AddToSortedList<T>(this IList<T> list, T value)
        {
            return list.AddToSortedList(value, null);
        }
        public static int AddToSortedList<T>(this IList<T> list, T value, IComparer<T> comparer)
        {
            // If the incoming value is equivalent to the some value already in the list using the current comparer,
            // add it to the END of the sequence of equivalent entries.
            int index = list.BinarySearchLast(value, comparer);
            if (index < 0)
                index = ~index;
            list.Insert(index, value);
            return index;
        }
    }
