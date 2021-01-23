    [ServiceKnownType(typeof(SomeTable))]
    [ServiceKnownType(typeof(SomeOtherTable))]
    [ServiceContract]
    public interface IYourService
    {
        [OperationContract]
        IEnumerable<T> GetTable<T>() where T: ITable, new();
    }
