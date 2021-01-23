    public static void ConfigureMobileApp(IAppBuilder app)
    {
        HttpConfiguration config = new HttpConfiguration();
        //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
        config.EnableSystemDiagnosticsTracing();
        config.MapHttpAttributeRoutes(); //Add this line
        new MobileAppConfiguration()
            .UseDefaultConfiguration()
            .ApplyTo(config);
        ... //rest of the code
    }
