    var _context = OperationContext.Current;
    var headers = _context.IncomingMessageHeaders; 
    foreach (MessageHeaderInfo h in headers)
    {
         if (h.Name == "AppID") {
            Debug.WriteLine(h.ToString());
         }
    }
