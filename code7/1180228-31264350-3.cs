    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Calculate(int price, int Qty);
    }
