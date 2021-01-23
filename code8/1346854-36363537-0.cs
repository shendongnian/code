    public static Image Resize(Image source, int width, int height)
    {
    	if (source.Width == width && source.Height == height) return source;
    	var result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
    	result.SetResolution(source.HorizontalResolution, source.VerticalResolution);
    	using (var g = Graphics.FromImage(result))
    		g.DrawImage(source, new Rectangle(0, 0, width, height), new Rectangle(0, 0, source.Width, source.Height), GraphicsUnit.Pixel);
    	return result;
    }
