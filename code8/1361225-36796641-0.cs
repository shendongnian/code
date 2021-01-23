    public async Task<IHttpActionResult> UploadImage()
    {
        FileDescription filedescription = null;
        var allowedExt = new string[] { ".png", ".jpg", ".jpeg" };
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        if (Request.Content.IsMimeMultipartContent())
        {
            await Request.Content.LoadIntoBufferAsync();
            var provider = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
    
            var content = provider.Contents.ElementAt(0);
            Stream stream = await content.ReadAsStreamAsync();
            Image image = Image.FromStream(stream);
            var receivedFileName = content.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            var getExtension = Path.GetExtension(receivedFileName);
            if (allowedExt.Contains(getExtension.ToLower()))
            {
                string newFileName = "TheButler" + DateTime.Now.Ticks.ToString() + getExtension;
                var originalPath = Path.Combine("Folder Path Here", newFileName);
                image.Save(originalPath);
                var picture = new Images
                {
                    ImagePath = newFileName
                };
                repos.ImagesRepo.Insert(picture);
                repos.SaveChanges();
                filedescription = new FileDescription(imagePath + newFileName, picture.Identifier);
            }
    
            if (filedescription == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = "some error msg." }));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, filedescription));
            }
        }
        else
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "This request is not properly formatted" }));
        }
    }
