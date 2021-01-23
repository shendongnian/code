    public class ObjectResult
    {
      public MessageString Message { get; set;}  
    }
    
    public class ObjectResult
    {
      public string Message { get; private set;}  
    
      public ObjectResult(MessageString message)
      {
        Message = message.GetDescription();
      }
    }
