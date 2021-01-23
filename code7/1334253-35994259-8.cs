        override internal void ExecuteTransaction(TransactionRequest transactionRequest, string name, IsolationLevel iso, SqlInternalTransaction internalTransaction, bool isDelegateControlRequest) {
            //SNIP
            if (!_parser.IsYukonOrNewer) {
                ExecuteTransactionPreYukon(transactionRequest, transactionName, iso, internalTransaction);
            }
            else {
                ExecuteTransactionYukon(transactionRequest, transactionName, iso, internalTransaction, isDelegateControlRequest);
            }
        }
        internal void ExecuteTransactionPreYukon(
                    TransactionRequest      transactionRequest, 
                    string                  transactionName, 
                    IsolationLevel          iso, 
                    SqlInternalTransaction  internalTransaction) {
            //SNIP
 
            Threading.Tasks.Task executeTask = _parser.TdsExecuteSQLBatch(sqlBatch.ToString(), 
                 ConnectionOptions.ConnectTimeout, null, _parser._physicalStateObj, sync: true);
            //SNIP
        }
        internal void ExecuteTransactionYukon(
                    TransactionRequest      transactionRequest, 
                    string                  transactionName, 
                    IsolationLevel          iso, 
                    SqlInternalTransaction  internalTransaction, 
                    bool                    isDelegateControlRequest) {
                //SNIP
                _parser.TdsExecuteTransactionManagerRequest(null, requestType, transactionName, isoLevel,
                    ConnectionOptions.ConnectTimeout, internalTransaction, stateObj, isDelegateControlRequest);
                //SNIP
        }
