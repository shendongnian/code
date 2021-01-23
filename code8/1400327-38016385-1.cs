    [ServiceContract]
    public interface IBoundGeneric
    {
         [OperationContract]
         GenericSample<int> GetObject(int id);
    }
