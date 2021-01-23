    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();
    
      config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
    }
