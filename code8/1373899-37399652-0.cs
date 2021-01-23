    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet]
        string GetData(int value);
        [OperationContract]
        [WebInvoke(Method="POST", RequestFormat = WebMessageFormat.Json)]
        void PostData(MyDataType data);
    }
