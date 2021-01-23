    public static IList<P> GenericFunction<P>(IList<P> objList)
        where P : IProduct // Here you can specify either the base class or the interface.
    {
        return objList
            .Where(p => p.Price > 0)
            .ToList();
    }    
