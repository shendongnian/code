    namespace MyApplication
    {
        [ServiceContract]
        public interface ITransactionService1
        {
            [OperationContract]
            int DoSomething(string arg);
        }
        public class TransactionService1 : ITransactionService1
        {
            // Implementation logic
        }
    }
