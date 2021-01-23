    public class InfoMessage
    {
      public string Message { get; private set; }
      public string MemberName { get; private set; }
      public int LineNumber { get; private set; }
      public InfoMessage(string message,
                         [CallerMemberName] string memberName = "", 
                         [CallerLineNumber] int lineNumber = 0)
      {
        Message = message;
        MemberName = memberName;
        LineNumber = lineNumber;
      }
    }
     
    public void Info(InfoMessage infoMessage, params object[] args)
    { 
      _log.Info(BuildMessage(infoMessage), args);
    }
    public string BuildMessage(InfoMessage infoMessage)
    {
      return BuildMessage(infoMessage.Message, 
        infoMessage.MemberName, infoMessage.LineNumber);
    }
      
    void Main()
    {
      Info(new InfoMessage("Hello"));
    }
