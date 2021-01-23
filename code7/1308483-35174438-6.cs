    string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringsName"].ConnectionString;
            protected void Application_Start()
            {
                SqlDependency.Start(ConnectionString);
            }
            protected void Application_End()
            {
                SqlDependency.Stop(ConnectionString);
            }
