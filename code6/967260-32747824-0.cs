         public HttpResponseMessage Image(int pIndice)
            {
     var response = new HttpResponseMessage(HttpStatusCode.OK);
    
     using (var binaryReader = new BinaryReader(requestFile[pIndice].InputStream))
     {
         response.Content = new ByteArrayContent(binaryReader.ReadBytes(requestFile[pIndice].ContentLength));
       response.Content.Headers.ContentType = new MediaTypeHeaderValue(requestFile[pIndice].ContentType ?? "image/jpeg");
     }
    return response; 
    }
