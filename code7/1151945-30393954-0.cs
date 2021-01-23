    public IList<IWrapped<Entity1>> GetAllEntity1()
    {
        return GetAll<Entity1>.Select(e => new Entity1Wrapper(e)).ToList();
    }
    public IList<IWrapped<Entity2>> GetAllEntity2()
    {
        return GetAll<Entity1>.Select(e => new Entity2Wrapper(e)).ToList();
    }
    //...
    private IList<T> GetAll<T>()
    {
        //Get IList<T> entityList by querying
        return entityList;
    }
