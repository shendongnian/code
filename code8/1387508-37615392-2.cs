    private static IEnumerable<T> GetDependencies(T oi)
    {
        return new FlattenedCircularTree<OwnedItem>(oi, o => o.AllUsedOwnedItemsToBeIncluded)
           .AllNodes();
    }
