    interface IProduct
    {
        double Price { get; }
    }
    public static IList<T> GenericFunction<T>(IList<T> objList) where T : IProduct
    {
        IList<T> filteredData = objList.Where(p => p.Price > 0));
    }
