    public IHttpActionResult UploadImage(ImageModel model)
    {
        var imgUrl = WriteImage(model.Bytes);
    	
    	// Some code
    }
