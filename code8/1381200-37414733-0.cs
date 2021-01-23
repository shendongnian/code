    public string UploadImage()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(new HttpResponseMessage((HttpStatusCode.UnsupportedMediaType)));
            }
            var context = HttpContext.Current.Request;
            if (context.Files.Count > 0)
            {
                var resourcePhoto = new PhotoHelper(HttpContext.Current.Server.MapPath("~"));
                var file = context.Files.AllKeys.FirstOrDefault();
                var result = resourcePhoto.SaveResourceImage(context.Files[file], User.Identity.Name);
                return result;
            }
            else
            {
                return null;
            }
        }
