        protected void Application_Start()
        {
            ...
            string l4net = Server.MapPath("~/log4net.config");
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(l4net));
        }
