    public static class ImageUtils
    {
    	public static Bitmap CropImage(this PictureBox pb, int x, int y, int w, int h)
    	{
    		var imageRect = pb.GetImageRectangle();
    		var image = pb.Image;
    		float scaleX = (float)image.Width / imageRect.Width;
    		float scaleY = (float)image.Height / imageRect.Height;
    		var cropRect = new Rectangle();
    		cropRect.X = Scale(x - imageRect.X, scaleX, image.Width);
    		cropRect.Y = Scale(y - imageRect.Y, scaleY, image.Height);
    		cropRect.Width = Scale(w, scaleX, image.Width - cropRect.X);
    		cropRect.Height = Scale(h, scaleY, image.Height - cropRect.Y);
    		var result = new Bitmap(cropRect.Width, cropRect.Height, image.PixelFormat);
    		using (var g = Graphics.FromImage(result))
    			g.DrawImage(image, new Rectangle(new Point(0, 0), cropRect.Size), cropRect, GraphicsUnit.Pixel);
    		return result;
    	}
    
    	static int Scale(int value, float scale, int maxValue)
    	{
    		int result = (int)(value * scale);
    		return result < 0 ? 0 : result > maxValue ? maxValue : result;
    	}
    
    	public static Rectangle GetImageRectangle(this PictureBox pb)
    	{
    		var rect = pb.ClientRectangle;
    		var padding = pb.Padding;
    		rect.X += padding.Left;
    		rect.Y += padding.Top;
    		rect.Width -= padding.Horizontal;
    		rect.Height -= padding.Vertical;
    		var image = pb.Image;
    		var sizeMode = pb.SizeMode;
    		if (sizeMode == PictureBoxSizeMode.Normal || sizeMode == PictureBoxSizeMode.AutoSize)
    			rect.Size = image.Size;
    		else if (sizeMode == PictureBoxSizeMode.CenterImage)
    		{
    			rect.X += (rect.Width - image.Width) / 2;
    			rect.Y += (rect.Height - image.Height) / 2;
    			rect.Size = image.Size;
    		}
    		else if (sizeMode == PictureBoxSizeMode.Zoom)
    		{
    			var imageSize = image.Size;
    			var zoomSize = pb.ClientSize;
    			float ratio = Math.Min((float)zoomSize.Width / imageSize.Width, (float)zoomSize.Height / imageSize.Height);
    			rect.Width = (int)(imageSize.Width * ratio);
    			rect.Height = (int)(imageSize.Height * ratio);
    			rect.X = (pb.ClientRectangle.Width - rect.Width) / 2;
    			rect.Y = (pb.ClientRectangle.Height - rect.Height) / 2;
    		}
    		return rect;
    	}
    }
