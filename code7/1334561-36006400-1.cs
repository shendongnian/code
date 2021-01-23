    public static Bitmap Crop(PictureBox pb, int x, int y, int w, int h)
    {
    	var rect = pb.ClientRectangle;
    	using (var output = new Bitmap(rect.Width, rect.Height, pb.Image.PixelFormat))
    	{
    		pb.DrawToBitmap(output, rect);
    		return output.Clone(new Rectangle(x, y, w, h), output.PixelFormat);
    	}
    }
