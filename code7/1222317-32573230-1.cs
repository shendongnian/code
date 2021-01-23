    public class Startup
    {
       public void Configuration(IAppBuilder appBuilder)
       {
           var httpConfiguration = new HttpConfiguration();
           ...
           AutoFacConfig.ConfigureAutoFac(httpConfiguration);
           appBuilder.UseAutofacMiddleware(AutoFacConfig.Container);
           appBuilder.UseAutofacWebApi(httpConfiguration);
           appBuilder.UseWebApi(httpConfiguration);
       }
    }
