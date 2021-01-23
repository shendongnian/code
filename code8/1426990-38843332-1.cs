    using (MemoryStream mStream = new MemoryStream(arr))
    {
        mStream.Seek(0, SeekOrigin.Begin);
        System.Drawing.Image Img = System.Drawing.Image.FromStream(mStream);
        Img.Save(Server.MapPath("StudentImages") + "//test.jpg");
    }
