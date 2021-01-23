    [ServiceContract]
    public interface IRestService {
        [OperationContract]
        [WebGet(UriTemplate = "operations/{delimitedValues}")]
        void Operations(string delimitedValues);
    }
