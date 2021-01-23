        public static BitmapImage ConvertToBitmapImageFromBitmap(Bitmap bitmap)
		{
			using(var memory = new MemoryStream())
			{
				BitmapImage bitmapImage;
				bitmap.Save(memory, ImageFormat.Png);
				memory.Position = 0;
				bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				return bitmapImage;
			}
		}
