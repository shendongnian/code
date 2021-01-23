    public static class IocCOnfig
    {
      public static void Start()
      {
        var builder = new ContainerBuilder();
        builder.Register(r => new ConnectionSettings
        {
          DataWarehouse = ConfigurationManager.ConnectionStrings["DataWarehouse"],
          // etc
        });
      }
      private class ConnectionSettings : IConnectionSettings
      {
        // implement interface...
      }
    }
