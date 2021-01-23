	public static int[,] ToInteger(Bitmap bitmap)
	{
		int[,] array2D = new int[bitmap.Width, bitmap.Height];
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
												ImageLockMode.ReadWrite,
												PixelFormat.Format8bppIndexed);
		int bytesPerPixel = sizeof(byte);
		unsafe
		{
			byte* address = (byte*)bitmapData.Scan0;
			int paddingOffset = bitmapData.Stride - (bitmap.Width * bytesPerPixel);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					byte[] temp = new byte[bytesPerPixel];
					for (int k = 0; k < bytesPerPixel; k++)
					{
						temp[k] = address[k];
					}
					int iii = 0;
					if (bytesPerPixel >= sizeof(int))
					{
						iii = BitConverter.ToInt32(temp, 0);
					}
					else
					{
						iii = (int)temp[0];
					}
					array2D[j, i] = iii;
					address += bytesPerPixel;
				}
				address += paddingOffset;
			}
		}
		bitmap.UnlockBits(bitmapData);
		return array2D;
	}
	public static Bitmap ToBitmap(int[,] image)
	{
		int Width = image.GetLength(0);
		int Height = image.GetLength(1);
		int i, j;
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height),
								 ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
		int bytesPerPixel = sizeof(byte);
		unsafe
		{
			byte* address = (byte*)bitmapData.Scan0;
			for (i = 0; i < bitmapData.Height; i++)
			{
				for (j = 0; j < bitmapData.Width; j++)
				{
					byte[] bytes = BitConverter.GetBytes(image[j, i]);
					for (int k = 0; k < bytesPerPixel; k++)
					{
						address[k] = bytes[k];
					}
					address += bytesPerPixel;
				}
				address += (bitmapData.Stride - (bitmapData.Width * bytesPerPixel));
			}
		}
		bitmap.UnlockBits(bitmapData);
		Grayscale.SetGrayscalePalette(bitmap);
		return bitmap;
	}
