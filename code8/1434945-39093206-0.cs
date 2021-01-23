    //mark the method as async
    private async System.Threading.Tasks.Task<AdmAccessToken> HttpPost(string DatamarketAccessUri, string requestDetails)
    {
        ...
        //use 'GetRequestStreamAsync'
        using (Stream outputStream =await webRequest.GetRequestStreamAsync())
        {
            ...
        }
        //use 'GetResponseAsync' instead
        using (WebResponse webResponse = await webRequest.GetResponseAsync())
        {
            ...
            return token;
        }
    }
