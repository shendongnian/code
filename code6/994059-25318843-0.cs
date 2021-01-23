    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    namespace WcfService1
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet]
            string GetTime();
        }
    }
