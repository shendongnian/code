    List<int> obj = new List<int>();
    using (DemoEntities context = new DemoEntities())
    {
        obj = (from ct in context.CTransactions
        group ct by ct.Transactionid into grp
        join pt in context.PTransactions on grp.Key equals pt.Transactionid
        where grp.Sum(x => x.DepositAmount) < pt.PayAmount
        select grp.Key).ToList();
    }
