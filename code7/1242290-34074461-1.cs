    try{
        response = (HttpWebResponse)authClient.Post<AccessTokenResponse>(authRequest);
        wRespStatusCode = response.StatusCode;
    }
    catch (WebException we)
    {
        wRespStatusCode = ((HttpWebResponse)we.Response).StatusCode;
        // ...
    }
