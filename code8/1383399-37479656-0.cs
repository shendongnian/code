    public HttpResponseMessage DownloadCsv()
            {
                const string csv = "mobile,type,amount\r\n123456789,0,200\r\n56987459,0,200";
    
                var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(csv)};
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Sample.csv"
                };
                return result;
            }
