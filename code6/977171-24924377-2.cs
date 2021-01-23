    public T SaveOrUpdate(T entity) 
    { 
        using (Session) 
        { 
            using (TransactionScope scope = new TransactionScope())
            { 
                Session.SaveOrUpdate(entity); scope.Complete(); 
            } 
            return entity; 
        } 
    }
