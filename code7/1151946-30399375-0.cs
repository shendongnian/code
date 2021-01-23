    public static class GetWrapper<T>
    {
        static GetWrapper()
        {
            GetWrapper<Entity1>.CreateWrapper = v => new Entity1Wrapper(v);
            GetWrapper<Entity2>.CreateWrapper = v => new Entity2Wrapper(v);
            GetWrapper<Entity3>.CreateWrapper = v => new Entity3Wrapper(v);
        }
        public static Func<T, IWrapped<T>> CreateWrapper { get; set; }
    }
    public IList<IWrapped<T>> GetAll<T>()
    {
        IList<IWrapped<T>> retList = new List<IWrapped<T>>();
        //Get IList<T> entityList by querying
        IList<T> entityList = new List<T> { default(T) };
        var createWrapper = GetWrapper<T>.CreateWrapper;
        if (createWrapper == null)
        {
            throw new Exception("Wrapper not found for type " + typeof(T).Name);
        }
        foreach (T elem in entityList)
        {
            retList.Add(createWrapper(elem));
        }
        return retList;
    }
