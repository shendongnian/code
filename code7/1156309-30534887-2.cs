    public Bitmap AppendImageFooter(System.Drawing.Image bmp, System.Drawing.Image footer)
    {
        //Create new image that will be bigger then original image to make place for footer
        Bitmap newImage = new Bitmap(bmp.Height+footer.Height,bmp.Width);
        //Get graphics from new Image and copy original image and next footer below
        Graphics g = Graphics.FromImage(newImage);
        g.DrawImage(bmp, new Point(0, 0));
        g.DrawImage(footer, new Point(0, bmp.Height));
        g.Dispose();
        return newImage;
    }
