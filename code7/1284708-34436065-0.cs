    public static void Swap<T>(this ICollection<T> collection, T oldValue, T newValue)
    {
        // In case the collection is ordered, we'll be able to preserve the order
        var collectionAsList = collection as IList<T>;
        if (collectionAsList != null)
        {
            var oldIndex = collectionAsList.IndexOf(oldValue);
            collectionAsList.RemoveAt(oldIndex);
            collectionAsList.Insert(oldIndex, newValue);
        }
        else
        {
            // No luck, so just remove then add
            collection.Remove(oldValue);
            collection.Add(newValue);
        }
    
    }
