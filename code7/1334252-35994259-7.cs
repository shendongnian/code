       internal void Save(string savePointName) {
            //SNIP
                 _innerConnection.ExecuteTransaction(SqlInternalConnection.TransactionRequest.Save, savePointName, IsolationLevel.Unspecified, null, false);
            //SNIP
        }
