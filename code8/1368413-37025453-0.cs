    public static string GetByteArrayFromImage(BitmapSource writeableBitmap)
	{
		JpegBitmapEncoder encoder = new JpegBitmapEncoder();
		encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
		MemoryStream stream = new MemoryStream();
		encoder.Save(stream);
		Byte[] bytes = stream.ToArray();
		return Convert.ToBase64String(bytes);
	}
	public static BitmapSource GetImageFromByteArray(string base64String)
	{
		byte[] bytes = Convert.FromBase64String(base64String);
		MemoryStream stream = new MemoryStream(bytes);
		JpegBitmapDecoder decoder = new JpegBitmapDecoder(stream, 
            BitmapCreateOptions.None, BitmapCacheOption.Default);
		return decoder.Frames[0];
	}
