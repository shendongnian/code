    using (var transactionScope = new TransactionScope()) {
        try {
            string sql = @"
    DELETE SampleSentence 
    DELETE Synonym 
    DELETE WordForm
    ";
        
            int count = myDbContext.Database.ExecuteSqlCommand(sql);
            if(count > 0) 
                transactionScope.Complete();
        } catch(Exception ex) {
            //Logging
        }
    }
