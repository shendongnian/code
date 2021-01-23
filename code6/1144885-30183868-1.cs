    public static void AddList<T>(IList<IWrapped<T>> entities)
    {
       internalList = new List<IWrapped<T>>(); 
       list.AddRange(entities); // BOOM.
    }
