    public IList<PaymentType> SP_GetPaymentTypes()
    {
        using(var ctx = new StartupBusinessLogic())
        {
            var query = ctx. blablabla
            query = query.*more filtering*
            return query.ToList();
        }
     }
