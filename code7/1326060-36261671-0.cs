    public class WebApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GrpcInitializer.EnsureGrpcCSharpExtNativeDll();
        }
    }
