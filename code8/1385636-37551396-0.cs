    public abstract class BaseLogger
    {
         public abstract void LogException(Exception ex);
         public abstract void LogUserMessage(string userMessage);
         protected string GetStringFromException(Exception ex)
         {
            //....
         }
         protected string GetStringFromUserMessage(string userMessage)
         {
            //....  
         }
    }
