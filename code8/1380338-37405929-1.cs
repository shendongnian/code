    [ServiceContract]
    public interface IService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginProcess(IParameter parameter, AsyncCallback callback, object asyncState);
        IResult EndProcess(IAsyncResult result);
    }
