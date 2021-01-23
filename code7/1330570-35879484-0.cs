    public static IList<T> GenericFunction<T>(IList<T> objList)
        where T : IHasPrice // Here you can specify either the base class or the interface.
    {
        IList<T> filteredData = objList.Where(p => p.Price > 0));
    }    
