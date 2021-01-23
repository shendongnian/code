    Bitmap bmptoreturn;
    public Bitmap SaveRectanglePart(Image image, RectangleF sourceRect)
    {
        var bmp = new Bitmap((int)sourceRect.Width, (int)sourceRect.Height)
        using (var graphics = Graphics.FromImage(bmp))
        {
            graphics.DrawImage(image, 0.0f, 0.0f, sourceRect, GraphicsUnit.Pixel);
        }
        bmptoreturn = bmp;
    
        return bmptoreturn;
    }
    
