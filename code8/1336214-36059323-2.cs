    class TransScopeWrapper : ITransScope, IDisposable
    {
        private TransactionScope scope;
        public TransScopeWrapper()
        {
            scope = new TransactionScope();
        }
        public void Dispose()
        {
            scope.Dispose();
        }
        public void Complete()
        {
            scope.Complete();
        }
        public void Rollback()
        {
            ...
        }
    }
    
    internal interface ITransScope
    {
        void Complete();
        void Rollback();
    }
