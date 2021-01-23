       internal void Save(string savePointName) {
            //SNIP
 
            try {
                //SNIP
                if (ADP.IsEmpty(savePointName))
                    throw SQL.NullEmptyTransactionName();
 
                try {
                    _innerConnection.ExecuteTransaction(SqlInternalConnection.TransactionRequest.Save, savePointName, IsolationLevel.Unspecified, null, false);
                }
                catch (Exception e) {
                    // 
                    if (ADP.IsCatchableExceptionType(e)) {
                        CheckTransactionLevelAndZombie();
                    }
 
                    throw;
                }
            }
            finally {
                Bid.ScopeLeave(ref hscp);
            }
        }
