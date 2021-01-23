    public static string ResizeBase64ImageString(string Base64String, int desiredWidth, int desiredHeight)
    {
        Base64String = Base64String.Replace("data:image/png;base64,", "");
        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(Base64String);
        using (MemoryStream ms = new MemoryStream(imageBytes))
        {                
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            var imag = ScaleImage(image, desiredWidth, desiredHeight);
            using (MemoryStream ms1 = new MemoryStream())
            {
                //First Convert Image to byte[]
                imag.Save(ms1, imag.RawFormat);
                byte[] imageBytes1 = ms1.ToArray();
                //Then Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes1);
                return "data:image/png;base64,"+base64String;
            }
        }
    }
    public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
    {
        var ratioX = (double)maxWidth / image.Width;
        var ratioY = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratioX, ratioY);
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);
        using (var graphics = Graphics.FromImage(newImage))
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);
        return newImage;
    }
