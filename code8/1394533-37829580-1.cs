    try
    {
        ... make request
    }
    catch (WebException webExcp) 
    {
        Logger.Error(webExcp, "HttpRequest error: " + webExcp.Status);
        if (webExcp.Status == WebExceptionStatus.ProtocolError) {
            return (HttpWebResponse)webExcp.Response;            
        }
        throw;
    }
    catch(Exception ex)
    {
       // Other exception, not a WebException, you probably want to Log an throw
        Logger.Error(ex, "HttpRequest error"); 
       throw;
    }
