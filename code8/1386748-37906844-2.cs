    protected void Application_Start(object sender, EventArgs e)
    {
       DomainService.Factory = new MyDomainServiceFactory();
 
       UnityContainer.RegisterType<StoreService>();
       UnityContainer.RegisterType<IUnitOfWork, UnitOfWorkImpl>();
    }
