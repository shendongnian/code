         public static void Main()
         {
           string uri;
           StartupHelpers.SetConfigurationValue("ActivationUri", (StartupHelpers.HasTriggeredFromUrl(out uri)) ? uri : string.Empty);    
           if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
                {
                 var application = new App();
                 application.Run();
                 SingleInstance<App>.Cleanup();
                }
         }
