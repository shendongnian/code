    public void ProcessRequest(HttpContext context)
    {
        int id;
        if (int.TryParse(context.Request.QueryString["id"], out id))
        {
            Image img = new Bitmap(@"C:\Users\path\SliderImages\Wind"+id+".jpg");
            //Load Image id from the folder with
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.WriteTo(context.Response.OutputStream);
            }
        }
        context.Response.ContentType = "image/jpeg";
    }
