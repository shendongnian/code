    [ServiceContract]
    public interface IRestService {
        [OperationContract]
        [WebGet(UriTemplate = "operations/{values}")]
        void Operations(string[] values);
    }
