    public static class MyWebHostServiceServiceExtensions
    {
        public static void RunAsMyService(this IWebHost host)
        {
            var webHostService = new MyWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
    
    internal class MyWebHostService : WebHostService
    {
        public MyWebHostService(IWebHost host) : base(host)
        {
        }
    
        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }
    
        protected override void OnStarted()
        {
            base.OnStarted();
        }
    
        protected override void OnStopping()
        {
            base.OnStopping();
        }
    }
