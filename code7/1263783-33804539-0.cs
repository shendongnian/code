    public Task<IQueryable<HDFile>> Post()
    {
        try
        {
            var uploadFolderPath = HostingEnvironment.MapPath("~/App_Data/" + UploadFolder);
            log.Debug(uploadFolderPath);
     
            if (Request.Content.IsMimeMultipartContent())
            {
                var streamProvider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IQueryable<HDFile>>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    }
     
                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        return new HDFile(info.Name, Request.RequestUri.AbsoluteUri + "?filename=" + info.Name, (info.Length / 1024).ToString());
                    });
                    return fileInfo.AsQueryable();
                });
     
                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
        catch (Exception ex)
        {
            log.Error(ex);
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
        }
    }
