    class OwinTestConf
    {
      public void Configuration(IAppBuilder app)
      {
  	 HttpConfiguration config = new HttpConfiguration();
        config.Services.Replace(typeof(IAssembliesResolver), new TestWebApiResolver());
        config.MapHttpAttributeRoutes();
        app.UseWebApi(config);
    }
