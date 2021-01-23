    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
        string base64String = Convert.ToBase64String(ms.ToArray());
        //Your code
        byte[] imageBytes = Convert.FromBase64String(base64String);
        System.IO.MemoryStream ms2 = new System.IO.MemoryStream(imageBytes);
        image = Image.FromStream(ms2);
        image.Save("testImage.tif", System.Drawing.Imaging.ImageFormat.Tiff);
    }
