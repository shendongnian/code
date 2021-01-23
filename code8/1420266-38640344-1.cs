    [Route("getDataForUploadFiles")]
    [HttpPost]
    public async Task<HttpResponseMessage> getDataForUploadFiles()
    {
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var fileName = Path.Combine(root, Request.Headers.GetValues("X-File-Name").First());
        try
        {
            var writer = new StreamWriter(fileName);
            await Request.Content.CopyToAsync(writer.BaseStream);
            writer.Close();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        catch (System.Exception e) {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }
    }
