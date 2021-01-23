    public class Teacher
    {
       public IPublishing Publishing { get; }
    }
    interface IPublishing 
    {
       void Send();
       ISecurity Security { get; set; }
    }
    public NoPublishing : IPublishing
    {
      public void Send() 
      {
        Security.Initiate();
        // Send message (independent of security).
        Security.Terminate();
      }
    }
    public PublishDefault : IPublishing
    {
      public void Send()
      {
        // Send a message the default way
      }
    }
    interface ISecurity
    {
       void Initiate();
       void Terminate();
    }
    public class FederatedSecurity: ISecurity
    {
        public void Initiate() { /* implementation */ }
        public void Terminate() { /* implementation */ }
    }
    public class OwinSecurity : ISecurity
    {
        public void Initiate() { /* implementation */ }
        public void Terminate() { /* implementation */ }
    }
