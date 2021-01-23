    public async void testFileUploadWebDAV()
    {      
        string url = "http://localhost/webdav/";
        string userId = "xxx";
        string sessionId = "yyy";
                
        var filter = new HttpBaseProtocolFilter(); 
        filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
        filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.IncompleteChain);
                
        var filePicker = new FileOpenPicker();
        filePicker.FileTypeFilter.Add("*");
        filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        StorageFile file = await filePicker.PickSingleFileAsync();
        url += file.Name;
                
        httpClient = new HttpClient(filter);
        msg = new HttpRequestMessage(new HttpMethod("PUT"), new Uri(url));
                
        httpClient.DefaultRequestHeaders.Add("RequestId", file.DisplayName);
        httpClient.DefaultRequestHeaders.Add("UserId", userId);
        httpClient.DefaultRequestHeaders.Add("SessionId", sessionId);
        httpClient.DefaultRequestHeaders.Add("ContentType", file.ContentType);
              
        Certificate cert = msg.TransportInformation.ServerCertificate;
        //-----------------ADD FILE CONTENT TO BODY-----------
  
        HttpStreamContent content = new HttpStreamContent(await file.OpenReadAsync());
        try
        {
            HttpResponseMessage httpResponseContent = await httpClient.PutAsync(new Uri(url), content);
            Debug.WriteLine(httpResponseContent.ToString());
            if (httpResponseContent.IsSuccessStatusCode)
            {                        
                msg.Dispose();                        
                httpClient.Dispose();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }                    
    }
