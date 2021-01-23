    public static class ListExtension
    {
        public static List<T> FindGroup<T>(this List<T> mylist, Predicate<T> pred)
        {
            var first = mylist.FindIndex(pred);
            var last = mylist.FindLastIndex(pred);
            last += 1; // to get the Last Element
            return mylist.GetRange(first, last - first);
        }
    }
