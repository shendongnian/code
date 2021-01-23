    public static string WatermarkImagesInFolder(string url)
    {
        if (url == null)
            throw new Exception("URL must be provided");
        string path = HttpContext.Current.Server.MapPath(url);
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException();
        Directory.CreateDirectory(String.Format(@"{0}\watermarked", path));
        List<string> urls = GetJpgFilesFromFolder(path);
        foreach (string imageUrl in urls)
        {
            using(Image img = WatermarkImage(imageUrl))
            {
            string filename = Path.GetFileName(imageUrl);
            string filepath = String.Format(@"{0}\watermarked\{1}", path, filename);
            img.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        return "complete";
    }
    public static Image WatermarkImage(string filename)
    {
        Image image = Image.FromFile(filename);
        using (Image watermarkImage = Image.FromFile(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WatermarkImageUrl"])))
        using (Graphics imageGraphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            int x = (image.Width / 2 - watermarkImage.Width / 2);
            int y = (image.Height / 2 - watermarkImage.Height / 2);
            watermarkBrush.TranslateTransform(x, y);
            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
            return image;
        }
    }
