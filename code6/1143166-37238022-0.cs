    [ActionName("File")]
    [HttpGet]
    public HttpResponseMessage File()
    {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new System.IO.FileStream(yourFilePath, System.IO.FileMode.Open);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return response;
    }
