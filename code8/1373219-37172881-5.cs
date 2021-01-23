    private IList<T> GetList<T>(T Value)
    {
        IList<T> Result = new List<T>();
        Result.Add(Value);
        return Result;
    }
    private IList<double> GetDoubleList()
    {
        return GetList<double>(2.5);
    }
    private IList<long> GetLongList()
    {
        return GetList<long>(2); 
    }
