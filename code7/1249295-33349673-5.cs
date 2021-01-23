    using System.ServiceModel.Activation; // from assembly System.ServiceModel.Web
    protected void Application_Start(Object sender, EventArgs e)
    {
      RegisterRoutes(RouteTable.Routes);
    }
    void RegisterRoutes(RouteCollection routes)
    {
      routes.Add(new ServiceRoute("Services/Angular", new WebServiceHostFactory(), typeof(WCFNamespace.AngularService)));
    }
        
