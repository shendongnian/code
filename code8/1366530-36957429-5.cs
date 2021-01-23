    private ICollection<T> AddTo<T>(IEnumerable<T> toBeAdded, ICollection<T> collectionToBeExtended, Func<T, T, bool> comparer)
    {
        if (collectionToBeExtended == null)
        {
            collectionToBeExtended = new List<T>();
        }
        if (toBeAdded != null)
        {
            foreach (T t in toBeAdded)
            {
                if (!collectionToBeExtended.Any(existingT => comparer(t, existingT))))
                {
                    collectionToBeExtended.Add(t);
                }
            }
        }
        return collectionToBeExtended;
    }
