    public void DoSomething(int param)
    {
        using (TransScopeWrapper transactionScope = new TransScopeWrapper ())
        {
            DoSomething(param, transactionScope);
        }
    }
    
    internal void DoSomething(int param, ITransScope transaction) 
    { 
        factory.DoSomething(param);
        factory.DoSomethingElse(param);
        
        transaction.Complete();
    }
