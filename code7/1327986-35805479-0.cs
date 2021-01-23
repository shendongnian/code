    [Route("all")]
    [HttpGet]
    public HttpResponseMessage GetAll(HttpRequestMessage request)
    {
       
    HttpResponseMessage response = null;
    
    MemoryStream stream = _exportService.CreateDataStream();
    
    response = request.CreateResponse(HttpStatusCode.OK);
    
    response.Content = new ByteArrayContent(stream.GetBuffer());
    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    response.Content.Headers.Add("content-type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    
    return response;
 
    }
