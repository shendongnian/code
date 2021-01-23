    [WebGet(UriTemplate = "GenerateMarketStudyResult/{id}")]
    public Stream GetMarketStudyResult(string id)
    {
        var serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
    
        // create webRequest
        HttpWebRequest webRequest = createWebRequest(serviceUrl + "/" + requestId);
    
        // begin async call to web request
        IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
    
        // suspend this thread until call is complete. You might want to
        // do something usefull here like update your UI
        asyncResult.AsyncWaitHandle.WaitOne();
    
        // get the response from the completed web request
        var filename = string.Format("{0}.xlsx", "NewWorkbook");
        string physicalPath = HttpContext.Current.Server.MapPath("/FilesForExport");
        string relativePath = Path.Combine(physicalPath, filename).Replace("\\", "/");
        var filePath = relativePath;
    
        var memStream = new MemoryStream();
        // var filePath = directory + "\\NewWorkbook.xlsx";
        using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
        {
            webResponse.GetResponseStream().CopyTo(memStream);
        }
        memStream.Position = 0;
        
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        WebOperationContext.Current.OutgoingResponse.ContentLength = (int)memStream.Length;
        return memStream;
    }
