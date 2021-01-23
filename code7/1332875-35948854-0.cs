    public IHttpActionResult ExportCsvData()
    {
            var stream = new FileStream("Testcsv.csv", FileMode.Open, FileAccess.Read);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Testcsv.csv"
            };
            return ResponseMessage(response);
     }
