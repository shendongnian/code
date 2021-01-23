    public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                var artworkjson = httpRequest.Form[0];
                var artwork = JsonConvert.DeserializeObject<ArtWork>(artworkjson);
                if (artwork == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No saved");
                }
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    artwork.Picture = binaryReader.ReadBytes(file.ContentLength);
                }
                
                result = Request.CreateResponse(HttpStatusCode.Created, "ok");
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
