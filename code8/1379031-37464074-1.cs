    internal class CustomWebHostService : WebHostService
    {
        public CustomWebHostService(IWebHost host) : base(host)
        {
        }
        protected override void OnStarting(string[] args)
        {
            // Log
            base.OnStarting(args);
        }
        protected override void OnStarted()
        {
            // More log
            base.OnStarted();
        }
        protected override void OnStopping()
        {
            // Even more log
            base.OnStopping();
        }
    }
