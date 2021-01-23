        BackgroundJobServer _backgroundJobServer;
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("YOUR_CONNECTION_STRING");
            _backgroundJobServer = new BackgroundJobServer();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();
        }
