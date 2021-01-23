       internal void Save(string savePointName) {
            //SNIP
 
            try {
                //SNIP
                try {
                    _innerConnection.ExecuteTransaction(SqlInternalConnection.TransactionRequest.Save, savePointName, IsolationLevel.Unspecified, null, false);
                }
               //SNIP
            }
            //SNIP
        }
