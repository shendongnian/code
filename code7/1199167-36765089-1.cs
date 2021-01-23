    [HttpPost]
    [ResponseType(typeof(Models.Photo))]
    [Route("upload")]
    public async Task<IHttpActionResult> Upload()
    {
        var img = WebImage.GetImageFromRequest();
        if (img == null)
        {
            return BadRequest("Image is null.");
        }
        // Do whatever you want with the image (resize, save, ...)
        // In this case, I save the image to a cloud storage and
        // create a DB record to reference the image.
    }
