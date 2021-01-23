    static string Image2Base64(Image image)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
    static Bitmap Base642Image(string base64image)
    {
        try
        {
            byte[] imageBytes = Convert.FromBase64String(base64image);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Bitmap image = (Bitmap)Image.FromStream(ms, true);
            return image;
        }
        catch { return null; }
    }
