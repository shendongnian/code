    public static class OwinVisualStudioApiListenerManager
    {
        private static IDisposable _runningServer;
        public static DTE2 VisualStudioApi { get; set; }
        public static void StartServer(DTE2 visualStudioApi)
        {
            if (null != _runningServer)
                _runningServer.Dispose();
            VisualStudioApi = visualStudioApi;
            //nothing fancy about OwinStartup
            //see github file http://tinyurl.com/zt2bm8b
            _runningServer = WebApp.Start<OwinStartup>("http://localhost:9000");
        }
        public static void StopServer()
        {
            if (null != _runningServer)
                _runningServer.Dispose();
            VisualStudioApi = null;
        }
    }
