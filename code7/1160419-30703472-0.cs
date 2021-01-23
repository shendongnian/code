    public class MySqlWrapper : IDisposable {
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }
        int _transactionCount = 0;
        public void BeginTransaction() {
            _transactionCount++;
            if (_transactionCount == 1) {
                Transaction = Connection.BeginTransaction();
            }
        }
        public void CommitTransaction() {
            _transactionCount--;
            if (_transactionCount == 0) {
                Transaction.Commit();
                Transaction = null;
            }
            if (_transactionCount < 0) {
                throw new InvalidOperationException("Commit without Begin");
            }
        }
        public void Rollback() {
            _transactionCount = 0;
            Transaction.Rollback();
            Transaction = null;
        }
        public void Dispose() {
            if (null != Transaction) {
                Transaction.Dispose();
                Transaction = null;
            }
            Connection.Dispose();
        }
    }
