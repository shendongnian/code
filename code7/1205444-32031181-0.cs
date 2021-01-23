    webReq.BeginGetResponse(GetResponseCallback, request);
    void GetResponseCallback(IAsyncResult result)
    {
        HttpWebRequest request = result.AsyncState as HttpWebRequest;
        if (request != null)
        {
           try
           {
            WebResponse response = request.EndGetResponse(result);
            // use response 
           }
           catch (WebException e)
           {
            return;
           }
       }
    }
