    var base64 = string.Empty;
    using (MemoryStream ms = new MemoryStream())
    {
       yourImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
       base64 = Convert.ToBase64String(ms.ToArray());
    }
   
