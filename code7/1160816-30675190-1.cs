    try
    {
         var httpResponse = (HttpWebResponse)httpReq.GetResponse();
    }
    catch (WebException e)
    {
        // Here is where you handle the exception.
    }
