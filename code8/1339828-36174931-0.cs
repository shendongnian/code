    HttpWebResponse webResp;
    try
    {
        webResp = (HttpWebResponse)request.GetResponse();
    }
    finally
    {
        webResp.Dispose();
    }
