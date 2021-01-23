    protected override void OnApplicationStarted()
    {
        base.OnApplicationStarted();
        RouteTable.Routes.Add(new ServiceRoute("Test.svc", new NinjectServiceHostFactory(), typeof(Test)));
    }
  
