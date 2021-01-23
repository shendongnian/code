    public static class EnumerableExtensions
    {
        #region Methods
        public static IEnumerable<T> Unwind<T>(T first, Func<T, T> getNext) 
            where T : class
        {
            if (getNext == null)
                throw new ArgumentNullException(nameof(getNext));
            return Unwind(
                first: first,
                getNext: getNext,
                isAfterLast: item => 
                    item == null);
        }
        public static IEnumerable<T> Unwind<T>(
            T first,
            Func<T, T> getNext,
            Func<T, Boolean> isAfterLast)        
        {
            if (getNext == null)
                throw new ArgumentNullException(nameof(getNext));
            if (isAfterLast == null)
                throw new ArgumentNullException(nameof(isAfterLast));
            var current = first;
            while(!isAfterLast(current))
            {
                yield return current;
                current = getNext(current);
            }
        }
        
        #endregion
    }
