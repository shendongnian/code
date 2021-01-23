    // get the User Agent
    string userAgentText = HttpContext.Current.Request.UserAgent;
    
    // Process the User Agent, and extract the information you want: browser, OS, version...
    ...
    // Make the 301 redirection to the target URL programmatically
    HttpContext.Current.Response.Status = "301 Moved Permanently";
    HttpContext.Current.Response.AddHeader("Location", TARGET_URL);
