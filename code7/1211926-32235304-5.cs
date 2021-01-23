    [WebGet(UriTemplate = "GenerateMarketStudyResult/{id}")]
    public Stream GenerateMarketStudyResult(string id)
    {
        var serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
    
        // create webRequest
        HttpWebRequest webRequest = createWebRequest(serviceUrl + "/" + id);
    
        // begin async call to web request
        IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
    
        // suspend this thread until call is complete. You might want to
        // do something usefull here like update your UI
        asyncResult.AsyncWaitHandle.WaitOne();
        
        var memStream = new MemoryStream();
        // var filePath = directory + "\\NewWorkbook.xlsx";
        using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
        {
            webResponse.GetResponseStream().CopyTo(memStream);
        }
        memStream.Position = 0;
        
        var response = WebOperationContext.Current.OutgoingResponse;
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.ContentLength = (int)memStream.Length;
        return memStream;
    }
