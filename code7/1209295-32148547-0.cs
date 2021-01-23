    public static TransactionScope CreateTransactionScope(TransactionScopeOption transactionScopeOption = TransactionScopeOption.Required)
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.MaximumTimeout
                };
    
                return new TransactionScope(transactionScopeOption, transactionOptions);
            }
