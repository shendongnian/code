    HttpWebResponse response = null;
    var request = (HttpWebRequest)WebRequest.Create("http://bar.vo.msecnd.net/cdn/test.png");
    request.Method = "HEAD";
    
    
    try
    {
        response = (HttpWebResponse)request.GetResponse();
    }
    catch (WebException ex)
    {
        /* do something here */
    }
    finally
    {
        // Don't forget to close your response.
        if (response != null)
        {
            response.Close()
        }
    }
