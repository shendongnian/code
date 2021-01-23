            public EfMyCustomContext(string connctionString)
            : base(string.Format(CONNECTION_STRING, connctionString))
        {
    #if DEBUG
            this.Database.Log = LogDataBaseCall;
    #endif
        }
    
    #if DEBUG
            private void LogDataBaseCall(string s)
            {
                if (s.Contains("Executing "))
                {
                    if (!s.Contains("asynchronously"))
                    {
                        // This code was not executed asynchronously
                        // Please look at the stack trace, and identify what needs
                        // to be loaded. Note, an entity.SomeOtherEntityOrCollection can be loaded
                        // with the eConnect API call entity.SomeOtherEntityOrCollectionLoadAsync() before using the 
                        // object that is going to hit the sub object. This is the most common mistake
                        // and this breakpoint will help you identify all synchronous code. 
                        // eConnect does not want any synchronous code in the code base.
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
    #endif
