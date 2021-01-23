    public void Image(string id){
        var base64String="";// get from id
        byte[] bytes = Convert.FromBase64String(base64String);
        Image image;
        Response.ContentType = "image/jpeg";
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
            image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
