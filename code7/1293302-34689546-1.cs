    public static bool IsCollectionNullOrEmpty<T>(ICollection<T> instance)
    {
        if (instance == null)
        {
            return true;
        }
        return instance.Count <= 0; // this does the exact same thing as your previous else block except it's massively simpler and doesn't create a new list
    }
