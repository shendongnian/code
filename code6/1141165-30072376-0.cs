    [OperationContract]
    public List<Patients> GetAll_Patients()
    {
    List<Patients> obj_Lst_t;
    using (var ctx = new EpriscriptionContext())
    {
    ctx.Configuration.ProxyCreationEnabled = false;
    obj_Lst_t = ctx.Patients.ToList();
    }
    return obj_Lst_t;
    }
