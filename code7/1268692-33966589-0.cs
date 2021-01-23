		public async Task<byte[]> GetBytesFromImage(string filePath)
		{
			ConvertImageToBW(filePath);
			// Create another bitmap that will hold the results of the filter.
			Bitmap thresholdedBitmap = Bitmap.CreateBitmap (BitmapFactory.DecodeFile(filePath));
			thresholdedBitmap = BitmapFactory.DecodeFile (thresholdedImagePath);
			byte[] bitmapData;
			using (var stream = new MemoryStream())
			{
				thresholdedBitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
				bitmapData = stream.ToArray();
			}
			return bitmapData;
		}
