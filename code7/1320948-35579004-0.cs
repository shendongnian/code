        private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
        void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            log.Error("App_Error", ex);
        }
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
