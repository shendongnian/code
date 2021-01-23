    public class WebApiApplication : HttpApplication
    {
        private static Kernel globalKernel;
        public static IKernel Kernel
        {
            get { return (IKernel) HttpContext.Current.Items["Context"]; }
            set { HttpContext.Current.Items["Context"] = value; }
        }
        protected void Application_Start()
        {
            .....
            globalKernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = 
                         new NinjectDependencyResolver(globalKernel);
            Debug.WriteLine("Application started with kernel: {0}", globalKernel);
        }
        protected void Application_BeginRequest()
        {
            // This adds the Kernel to the items collection that is specific to the request
            Kernel = globalKernel;
            Debug.WriteLine("Application begin request with kernel: {0}", Kernel);
        }
