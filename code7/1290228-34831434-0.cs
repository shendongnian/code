    [ServiceContract]
    public interface IPrintService
    {
        [OperationContract]
        string Print(Stream wordDoc);
    }
