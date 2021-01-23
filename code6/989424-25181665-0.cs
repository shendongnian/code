    // Load the image (probably from your stream)
    Image image = Image.FromFile( imagePath );
    using (Graphics g = Graphics.FromImage(image))
    {
        Color customColor = Color.FromArgb(50, Color.Gray);
        SolidBrush shadowBrush = new SolidBrush(customColor);
        g.FillRectangles(shadowBrush, new RectangleF[] { rectFToFill });
    }
    image.Save( imageNewPath );
