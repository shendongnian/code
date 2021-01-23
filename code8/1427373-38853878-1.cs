    try 
    {
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    }
    catch (WebException ex) 
    {
        if((ex.Response as System.Net.HttpWebResponse).StatusCode == ProxyAuthenticationRequired)
        {
            // Do Something
        }
    }
