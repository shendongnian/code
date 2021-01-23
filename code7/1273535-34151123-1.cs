    [Route("api/Account/UpdateProfile")]
    [HttpPost]
    public Task<HttpResponseMessage> UpdateProfile(/* UpdateProfileModel model */)
    {
         string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (MultipartFileData file in provider.FileData)
            {
            }
    }
