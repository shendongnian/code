       string contentDisposition = "inline; filename=abc.json";
       byte[] byteInfo = Encoding.ASCII.GetBytes(result)
       HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, byteInfo, MediaTypeHeaderValue.Parse("application/json"));
       response.Content.Headers.ContentDisposition = ContentDispositionHeaderValue.Parse(contentDisposition);
       response.Content.Headers.ContentLength = byteInfo.Length;
       return response;
