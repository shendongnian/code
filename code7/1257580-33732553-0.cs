    public class ZipController : ApiController
        {
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            [System.Web.Http.HttpGet]
            public HttpResponseMessage DownloadFile()
            {
                var zipPath = ConfigurationManager.AppSettings["FilePath"];
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(zipPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    if (File.Exists(zipPath))
                    {
    
                        result.Content = new StreamContent(stream);
                        result.Content.Headers.ContentType =
                            new MediaTypeHeaderValue("application/octet-stream");
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "abc.zip"
    
                        };
    
                    }
                }
                catch (Exception ex)
                {
                    LogError.LogErrorToFile(ex);
                }
                return result;
            }
         }
