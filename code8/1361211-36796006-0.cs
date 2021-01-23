    private IVisitorService VisitorService { get; set; }
    
    public MyRoleProvider()
    {
       var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
       var cp = cpa.ContainerProvider;
    
       VisitorService = cp.RequestLifetime.Resolve<IVisitorService>();
    }
