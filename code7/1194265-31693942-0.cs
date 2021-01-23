    void YourMethod()
    {
        string url2 = Sites[i].ToString();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url2));
        var response = GetResponse(request); // This is now a save call
        if (response.StatusCode != HttpStatusCode.OK)
        {
            // Send mail
        }
    }
    private HttpWebResponse GetResponse(HttpWebRequest request)
    {
        try
        {
            return (HttpWebResponse)request.GetResponse();
            // Everything ok, if we get here
        }
        catch (System.Net.WebException e)
        {
            if (e.Response == null)
                throw; // If you end here, something terrible did happen...
            return (HttpWebResponse)e.Response;
        }
    }
