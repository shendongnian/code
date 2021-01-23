    public static Byte[] ConvertToByteFromBitmapImage(BitmapImage bitmapImage)
    {
    	byte[] data;
    	JpegBitmapEncoder encoder = new JpegBitmapEncoder();
    	
    	encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
    	using(MemoryStream ms = new MemoryStream())
    	{
    		encoder.Save(ms);
    		data = ms.ToArray();
    	}
    	bitmapImage.Freeze();
    	return data;
    }
