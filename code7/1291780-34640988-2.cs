    public static Image GetImageFromPicPath(string strUrl)
    {
        WebResponse wrFileResponse;
        wrFileResponse = WebRequest.Create(strUrl).GetResponse();
        using (Stream objWebStream = wrFileResponse.GetResponseStream())
        {
            MemoryStream ms = new MemoryStream(); 
            objWebStream.CopyTo(ms, 8192);
            return System.Drawing.Image.FromStream(ms); 
        }
    }
