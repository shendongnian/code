    [ComVisible(true)]
    [Guid("B77F7C65-0F9F-422A-A897-C06FDAEC9604")]
    [ProvideObject(typeof(InitializerPackage))]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists)]
    public class InitializerPackage : Package
    {
        protected override void Initialize()
        {
            base.Initialize();
            //Get copy of current DTE
            var dte = (DTE)GetService(typeof(DTE));
            var dte2 = dte as DTE2;
            dte2.Events.SolutionEvents.Opened += () => 
                 OwinVisualStudioApiListenerManager.StartServer(dte2);
            dte2.Events.SolutionEvents.AfterClosing += () => 
                 OwinVisualStudioApiListenerManager.StopServer();           
        }
    }
    
