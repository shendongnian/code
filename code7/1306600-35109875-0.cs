    using Ws.ServiceModel;
    namespace FooService
    {
        [ServiceContract]
        public interface FooService
        {
            [OperationContract]
            void Start();
        }
    }
