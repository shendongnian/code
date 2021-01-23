    using System.ServiceModel;
    namespace Yourservice
    {
       [ServiceContract]
       public interface IExecuteScript
       {
           [OperationContract]
           void Execute();
       }
    }
