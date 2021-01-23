    public class Teacher
    {
       public IPublishing Publishing { get; }
    }
    interface IPublishing 
    {
       void Send();
    }
    public NoPublishing : IPublishing
    {
      public void Send() 
      {
         // Implementatation
      }
    }
    public PublishDefault : IPublishing
    {
      public void Send()
      {
        // Send a message the default way
      }
    }
