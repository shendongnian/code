    static int _processCount;
    static object _lockObj = new object();
    
    public Response ProcessRequest(Request request) {
         lock (_lockObj) {
             _processCount++;
             var savedCount = _processCount;
    
             // Make long running request
    
             if (savedCount != _processCount)
                throw new InvalidOperationException("Is my lock broken?");
         }
    }
