    using(System.Drawing.Image upImage =  System.Drawing.Image.FromFile(Server.MapPath("~/IMAGEUPLOADCENTER/" + foldername1 + "/") + name))     
    using(System.Drawing.Image logoImage = System.Drawing.Image.FromFile(Server.MapPath("~/pages002248Xc54/UploadImages/LOGOnew.png")))
    using (Graphics g = Graphics.FromImage(upImage))
    {
        g.DrawImage(logoImage, new Point(upImage.Width - logoImage.Width - 10, 10));
        upImage.Save(Server.MapPath("~/IMAGEUPLOADCENTER/" + foldername + "/") + name);
    }
    File.Delete(Server.MapPath("~/IMAGEUPLOADCENTER/" + foldername1 + "/") + name);
