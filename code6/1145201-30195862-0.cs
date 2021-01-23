    namespace WcfServiceLibrary
    {  
        [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            List<string> GetMeterBlinkData();
        }
    }
