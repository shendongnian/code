    public JsonResult UploadFile(string base64Image)
    {
        string result = string.Empty;
        try
        {
            string newstrImage = Regex.Replace(base64Image, "^data:image/(png|jpg|jpeg|bmp|gif);base64,", string.Empty);
            byte[] imageData = Convert.FromBase64String(newstrImage);
            var stream = new MemoryStream(imageData);
            stream.Seek(0, SeekOrigin.Begin);
            string fileName = System.Guid.NewGuid().ToString();
            var imgurl = string.Empty;
            var imgdata = BlobUtility.UploadBlob("triplecourtimages", fileName, "image/png", stream);
    if (imgdata)
      imgurl = BlobUtility.GetBlobUrl("triplecourtimages", fileName);
            result = string.Format("Upload successfully,image path:\r\n{0}", imgurl);
        }
        catch (Exception ex)
        {
            result = string.Format("Error:{0}", ex.Message);
        }
        return Json(result, JsonRequestBehavior.DenyGet);
    }
