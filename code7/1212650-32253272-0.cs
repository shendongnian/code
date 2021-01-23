    class Transaction : IDisposable
    {
        bool isCommitted;
        public void Commit() { ... }
        public void Dispose() { ... }
        public void RunTransaction() { ... }
    }
