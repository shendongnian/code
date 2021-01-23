    public static bool IsCollectionNullOrEmpty<T>(IEnumerable<T> instance)
    {
        if (instance == null)
        {
            return true;
        }
        return !instance.Any();
    }
