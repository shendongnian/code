    Image origImage;
    using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read);
    {
        origImage = Image.FromStream(s);
    }
    using (Image newImage = new Bitmap(origImage))
    {
        Graphics graphics = Graphics.FromImage(newImage);
        graphics.DrawString("Software version: " + version, font, Brushes.Black, 0, 0);
        newImage.Save(newPath, ImageFormat.Jpeg);
    }
    origImage.Dispose();
