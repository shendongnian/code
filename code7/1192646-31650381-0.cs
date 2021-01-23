    public static Bitmap CropImage(Image source, int x,int y,int width,int height)
    {
        Rectangle crop = new Rectangle(x, y, width, height);
    
        var bmp = new Bitmap(crop.Width, crop.Height);
        using (var gr = Graphics.FromImage(bmp))
        {
            gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
        }
        return bmp;
    } 
