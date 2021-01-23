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
 
                if (internalTransaction != null && internalTransaction.RestoreBrokenConnection && releaseConnectionLock) {
                    Task reconnectTask = internalTransaction.Parent.Connection.ValidateAndReconnect(() => {                      
                        ThreadHasParserLockForClose = false;
                        _parserLock.Release();
                        releaseConnectionLock = false;
                    }, 0);
                    if (reconnectTask != null) {
                        AsyncHelper.WaitForCompletion(reconnectTask, 0); // there is no specific timeout for BeginTransaction, uses ConnectTimeout
                        internalTransaction.ConnectionHasBeenRestored = true;
                        return;
                    }
                }                               
 
                //SNIP
                _parser.TdsExecuteTransactionManagerRequest(null, requestType, transactionName, isoLevel,
                    ConnectionOptions.ConnectTimeout, internalTransaction, stateObj, isDelegateControlRequest);
                //SNIP
        }
