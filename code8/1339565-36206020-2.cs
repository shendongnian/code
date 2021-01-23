    public IList<MyObject> GetSomeData(string inputParam)
    {
        //repository.GetData returns IEnumerable<IMyObject>
        var temp = repository.GetData(inputParam);
        var list = temp.Cast<MyObject>().ToList();
        return list;
    }
