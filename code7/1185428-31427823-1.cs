    using System.Transactions;
    
    public int SaveChanges(string modifierId)
    {
        using (var transaction = new TransactionScope()) 
        {
            SetUserContext(modifierId);
            var changes = base.SaveChanges();
            
            transaction.Complete();
        
            return changes;
        }
    }
        
