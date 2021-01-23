    public static string ResizeBase64ImageString(string Base64String, int desiredWidth, int desiredHeight)
    {
        Base64String = Base64String.Replace("data:image/png;base64,", "");
        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(Base64String);
        MemoryStream ms1 = new MemoryStream(imageBytes, 0,imageBytes.Length);
        // Convert byte[] to Image
        ms1.Write(imageBytes, 0, imageBytes.Length);
        Image image = Image.FromStream(ms1, true);
        float widthRatio = (float)image.Width / (float)desiredWidth;
        float heightRatio = (float)image.Height / (float)desiredHeight;
        // Resize to the greatest ratio
        float ratio = heightRatio > widthRatio ? heightRatio : widthRatio;
        int newWidth = Convert.ToInt32(Math.Floor((float)image.Width / ratio));
        int newHeight = Convert.ToInt32(Math.Floor((float)image.Height / ratio));
        byte[] bytes = Convert.FromBase64String(Base64String);
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            Bitmap thumb = new Bitmap(newWidth, newHeight);
            using (Image bmp = Image.FromStream(ms))
            {                    
                using (Graphics g = Graphics.FromImage(thumb))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawImage(bmp, 0, 0, newWidth, newHeight);
                }
            }
            thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage); //Get Base64
                
            return SigBase64;
        }
    }
