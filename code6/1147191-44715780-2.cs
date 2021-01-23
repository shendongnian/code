        BackgroundJobServer _server;
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("YOUR_CONNECTION_STRING");
            _server = new BackgroundJobServer();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            _server.Dispose();
        }
