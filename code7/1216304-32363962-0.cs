    private ICollateralItemBaseImplementation<T>     GetRepository(CollateralItemBase item)  where T : ServiceBaseRepository
    {
    switch (item.GetType().Name)
    {
            case "CollateralItemCertifiedDeposit": return new CollateralItemCertifiedDepositRepository();
            //...
    }
