         protected void Application_Start(object sender, EventArgs e)
                 {
            var config = GlobalConfiguration.Configuration;
            WebAPIConfig.Configure(config);
            
           
        }
           
       //Code that will configure all message handlers in webapi    
              public static void Configure(HttpConfiguration configure)
       {
          
            configure.MessageHandlers.Add(new xyzhandler());
           configure.MessageHandlers.Add(new ABCHandler());
       }
