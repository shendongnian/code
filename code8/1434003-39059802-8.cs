    public Image ResizeImage2(Image image, int canvasWidth, int canvasHeight)
    {
        // org size is already available
        Size orginalSize = image.Size;
        Size newSize = Size.Empty;
        float scale;
    
        if (canvasWidth != 0)
        {
            scale = (float)orginalSize.Height / orginalSize.Width;
            newSize = new Size(canvasWidth, Convert.ToInt32(scale * canvasWidth));
        }
        else if (canvasHeight != 0)
        {
            scale = (float)orginalSize.Width / orginalSize.Height;
            newSize = new Size(Convert.ToInt32(scale * canvasHeight), canvasHeight);
        }     
    
        //using (Image image2 = new Bitmap(canvasWidth, canvasHeight))
        Image image2 = new Bitmap(newSize.Width, newSize.Height);
        using (Graphics graphics = Graphics.FromImage(image2))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
                           
            graphics.Clear(Color.White);
            graphics.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
            
            return image2;
        }
    }
