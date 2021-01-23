    namespace WcfService1
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet(UriTemplate = "DoWork", ResponseFormat = WebMessageFormat.Json)]
            string DoWork();
        }
    }
