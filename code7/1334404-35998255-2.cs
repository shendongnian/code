    try
    {
        var response = (HttpWebResponse)(request.GetResponse());
    }
    catch(Exception ex)
    {
        var response = (HttpWebResponse)ex.Response;
    }
