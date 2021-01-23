    private string GetImageDimension()
    {
        System.IO.Stream stream = fu1.PostedFile.InputStream;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
     
        int height = image.Height;
        int width = image.Width;
     
        return "Height: " + height + "; Width: " + width;
    }
