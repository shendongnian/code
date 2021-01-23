    [ServiceContract]
    public interface IYourBulkCopyService {
    
        [OperationContract]
        void PerformBulkCopy();
    }
