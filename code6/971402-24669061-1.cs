       try
         {
        // Using HttpClient to avoid the 404 exception
                   HttpClient c = new HttpClient();
                   var resp = await c.SendAsync(new HttpRequestMessage(HttpMethod.Head, "http://www.example.com/img.jpg"));
                   bool ok = resp.StatusCode == HttpStatusCode.OK;
                    if (ok)
                    {
                             downloader.DownloadFile(url, destination);
                             return true;
                    }
         
         }
         catch(WebException webEx)
         {
         }
