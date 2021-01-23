    public static IList<T> GenericFunction<T>(IList<T> objList) where T : IProduct, new()
    {
        IList<T> retVal = new List<T>();
    
        foreach (T obj in objList)
        {
            T newObj = new T();
            newObj.Price = obj.BasePrice + obj.OldPrice;
            newObj.Description = obj.Name + " " + obj.Description;
            retVal.Add(newObj);
        }
        return retVal;
    }
