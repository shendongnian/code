    public HttpResponseMessage AddImageToScene2(long id, string type)
        {
            SceneHandler handler = null;
            try
            {
                
                var content = Request.Content;
                var asBytes = content.ReadAsByteArrayAsync().Result;
                using (handler = new SceneHandler()) // <-- my own custom class
                {
                    var image = new ImageNewOrUpdate(asBytes, type);
                    var response = handler.AddImage(id, image.Value, image.ImageType);
                    return Request.CreateResponse(HttpStatusCode.Created, response);
                }
            }
            catch (Exception ex)
            {
                return new HttpErrorResponseFactory(Request, ex, handler).GetResponse();
            }
        }
