    using (new TransactionScope(
                        TransactionScopeOption.Required, 
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted })) 
        {
            using (var db = new MyDbContext()) { 
                // query
            }
        }
