    [ServiceContract]
    public interface IDummySoap
    {
        [OperationContract]
        List<Response> GetResponses(int orderID);
    }
