    private ICollection<T> AddTo ( IEnumerable<T> toBeAdded , ICollection<T> collectionToBeExtended )
    {
        if ( collectionToBeExtended == null )
        {
            collectionToBeExtended = new List<T> ( );
        }
        if ( toBeAdded != null )
        {
            foreach ( T t in toBeAdded )
            {
                if (!collectionToBeExtended.Contains(t))
                {
                    collectionToBeExtended.Add(t);
                }
            }
        }
        return collectionToBeExtended;
    }
