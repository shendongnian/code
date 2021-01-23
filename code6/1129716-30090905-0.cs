    interface ILogger {
      void Critical (string message);
      void Error (string message);
      void Warning (string message);
      void Info (string message);
      void Verbose (string message);
      
      void SetContext(string context);
      string GetContext();
    }
    
    class Logger : ILogger {
      void Critical(string message) {
      	Debug.WriteLine(string.Format("{0}: {1}", GetContext(), message));
      }
      
      void SetContext(string context) {
      	CallContext.LogicalSetData("myContext", context);
      }
      
      string GetContext() {
      	return (string)CallContext.LogicalGetData("myContext") ?? string.Empty;
      }
    }
