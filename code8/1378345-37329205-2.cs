    public class Logger
    {
       public Task LogMessage(Exception ex)
       {
         return Task.Run(() => { \\ insert message });
       }
    }
