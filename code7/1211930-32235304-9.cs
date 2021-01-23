    public HttpResponseMessage GenerateMarketStudyResult([FromBody]Result id)
    {
        if (id.requestId == null)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }
        var serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];
    
        var streamContent = new PushStreamContent((outputStream, httpContext, transportContent) =>
        {
            try
            {
                HttpWebRequest webRequest = createWebRequest(serviceUrl + "/" + id.requestId);
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
    
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    webResponse.GetResponseStream().CopyTo(outputStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                outputStream.Close();
            }
        });
        streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        streamContent.Headers.ContentDisposition.FileName = "reports.xlsx";
    
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = streamContent
        };
        return result;
    }
    
