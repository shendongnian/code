	public delegate void WriteDelegate(string message, params object[] args);
    public static WriteDelegate Info(
          [CallerMemberName] string memberName = "", 
          [CallerLineNumber] int lineNumber = 0)
     {
         return new WriteDelegate ((message,args)=>
         {
             _log.Info(BuildMessage(message, memberName , lineNumber ), args);
         });
     }
