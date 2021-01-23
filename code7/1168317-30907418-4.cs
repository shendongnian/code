    public static class EnumerableExtensions
    {
        // Taken from http://stackoverflow.com/questions/19786101/native-c-sharp-support-for-checking-if-an-ienumerable-is-sorted
        public static bool IsOrdered<T>(this IEnumerable<T> collection, IComparer<T> comparer = null)
        {
            if (collection == null)
                throw new ArgumentNullException();
            comparer = comparer ?? Comparer<T>.Default;
            using (var enumerator = collection.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        if (comparer.Compare(previous, current) > 0)
                            return false;
                        previous = current;
                    }
                }
            }
            return true;
        }
    }
 
