    Map(mc =>
    {
        mc.Properties(n => new
        {
            n.IdPurchase,
            n.CodPurchase,
            n.IdCustomer,
            n.Total,
        });
        mc.ToTable("Purchases");
    });
