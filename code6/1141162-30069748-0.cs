    [OperationContract]
    public List<Drug> GetAll_Drug()
    {
        List<Drug> obj_Lst_t;
       var ctx = new EpriscriptionContext();
        
            ctx.Configuration.ProxyCreationEnabled = false; 
            obj_Lst_t = ctx.Drug.ToList();
    }
