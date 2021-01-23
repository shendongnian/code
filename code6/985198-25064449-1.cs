    public class ApplicationModeProvider
    {
      public override string ToString()
      {
        return Environment.UserInteractive ? "Console" : "Service";
      }
    }
