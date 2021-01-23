    #if DEBUG
    public LocalServiceClient Client {
         get {
              return new LocalServiceClient();
         }
    }
    #else
    public RemoteServiceClient Client {
         get {
              return new RemoteServiceClient();
         }
    }
    #endif
