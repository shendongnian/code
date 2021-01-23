    // Sends all currently buffered output 
    HttpContext.Current.Response.Flush(); to the client.
    // Gets or sets a value indicating whether to send HTTP content to the client.
    HttpContext.Current.Response.SuppressContent = true;
    
    /* Causes ASP.NET to bypass all events and filtering in the HTTP pipeline 
       chain of execution and directly execute the EndRequest event. */
    HttpContext.Current.ApplicationInstance.CompleteRequest(); 
