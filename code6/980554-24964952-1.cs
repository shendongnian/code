    protected void Application_Start()
        {
            GlobalConfiguration.Configuration.MessageHandlers
              .Add(new BasicAuthMessageHandler());
        }
