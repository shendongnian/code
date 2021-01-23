      class MyService : IMyService
        {
            public void Hello()
            {
             Console.WriteLine("Hello From Server..");
            }
        }
        [ServiceContract(CallbackContract = typeof(ICallbackService))]
        internal interface IMyService
       {
            [OperationContract]
            void Hello();
        }
        [ServiceContract]
        public interface ICallbackService
        {
            [OperationContract]
            void CallClient();
        }
