    HttpStatusCode code;
    try
    {
        //logic comes here
    }
    catch (WebException e)
    {
        code = ((HttpWebResponse)e.Response).StatusCode;
        throw;
    }
