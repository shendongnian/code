    [OperationContract]
    public List<Drug> GetAll_Drug()
    {
        List<Drug> obj_Lst_t;
        using (var ctx = new EpriscriptionContext())
        {
            ctx.Configuration.ProxyCreationEnabled = false; // disable proxy creation here.
            obj_Lst_t = ctx.Drug.ToList();
        }
        return obj_Lst_t;
    }
