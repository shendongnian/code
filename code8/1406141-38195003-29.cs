    public void DoSomethingWithData()
    {
        IDataAccessFactory dataAccessFactory = platformFactory.GetDataAccessFactory();
        IDataAccess dataAccess = dataAccessFactory.GetDataAccess();
        Console.WriteLine(dataAccess.GetData());
    }
