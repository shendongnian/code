    public static Image GetImageFromPicPath(string strUrl)
    {
        WebResponse wrFileResponse;
        wrFileResponse = WebRequest.Create(strUrl).GetResponse();
        using (Stream objWebStream = wrFileResponse.GetResponseStream())
        {
            var image = Image.FromStream(objWebStream);
            return image;
        }
    }
