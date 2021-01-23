    public static class DebugHelper
        
        public static Tuple<string,int> GetCallerInfo(
          [CallerMemberName] string memberName = "", 
          [CallerLineNumber] int lineNumber = 0)
        {
            return Tuple.Create(memberName,lineNumber);
        }
    }
