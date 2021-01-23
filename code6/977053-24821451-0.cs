    protected void Application_Start()
    {        
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        VoucherCompanyServiceLogic = DependencyResolver.Current.GetService<IVoucherCompanyServiceLogicInterface>();
        if(VoucherCompanyServiceLogic != null)
        {
            VoucherCompany vc = VoucherCompanyServiceLogic.GetByID(1, 1);
        }
    }
