		private static byte[] GetBitmapData(IntPtr hBitmap)
		{
			var source = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, null);
			// You may use Bmp, Jpeg or other encoder of your choice
			var encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(source));
			var stream = new MemoryStream();
			encoder.Save(stream);
			return stream.ToArray();
		}
		private static BitmapSource GetBitmapSource(byte[] data)
		{
			return BitmapFrame.Create(new MemoryStream(data));
		}
 
