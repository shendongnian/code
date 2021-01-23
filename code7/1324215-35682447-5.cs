    public static class EnumerableExtensions
    {
        #region Methods
        public static UnwoundItem<T> UnwindMany<T>(
            T first,
            Func<T, IEnumerable<T>> getNext)
            where T : class
        {
            if (getNext == null)
                throw new ArgumentNullException(nameof(getNext));
            return UnwindMany(
                first: first,
                getNext: getNext,
                isAfterLast: collection =>
                    collection == null);
        }
        public static UnwoundItem<T> UnwindMany<T>(
            T first,
            Func<T, IEnumerable<T>> getNext,
            Func<IEnumerable<T>, Boolean> isAfterLast)
        {
            if (getNext == null)
                throw new ArgumentNullException(nameof(getNext));
            if (isAfterLast == null)
                throw new ArgumentNullException(nameof(isAfterLast));
            var currentItems = getNext(first);
            if (isAfterLast(currentItems))
                return new UnwoundItem<T>(
                    item: first, 
                    unwoundSubItems: Enumerable.Empty<UnwoundItem<T>>());
            return new UnwoundItem<T>(
                item: first,
                unwoundSubItems: currentItems
                    .Select(item => 
                        UnwindMany(
                            item, 
                            getNext, 
                            isAfterLast)));
        }
        #endregion
    }
