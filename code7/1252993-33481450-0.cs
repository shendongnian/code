    using (Bitmap bitmap = new Bitmap(@"InputPath"))
    {
		Dictionary<Color, List<Color>> colourDictionary = new Dictionary<Color, List<Color>>();
		int nTolerance = 60;
		int nBytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
		System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
		try
		{
			int nByteCount = bitmapData.Stride * bitmap.Height;
			byte[] _baPixels = new byte[nByteCount];
			System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, _baPixels, 0, _baPixels.Length);
			int _nStride = bitmapData.Stride;
			for (int h = 0; h < bitmap.Height; h++)
			{
				int nCurrentLine = h * _nStride;
				for (int w = 0; w < (bitmap.Width * nBytesPerPixel); w += nBytesPerPixel)
				{
					int nBlue = _baPixels[nCurrentLine + w];
					int nGreen = _baPixels[nCurrentLine + w + 1];
					int nRed = _baPixels[nCurrentLine + w + 2];
					if (colourDictionary.Keys.Count > 0)
					{
						Color[] caNearbyColours = colourDictionary.Keys.Select(c => c)
							.Where(c => (int)c.B <= (nBlue + nTolerance) && (int)c.B >= (nBlue - nTolerance)
								&& (int)c.G <= (nGreen + nTolerance) && (int)c.G >= (nGreen - nTolerance)
								&& (int)c.R <= (nRed + nTolerance) && (int)c.R >= (nRed - nTolerance)).ToArray();
						if (caNearbyColours.Length > 0)
						{
							if (!colourDictionary[caNearbyColours.FirstOrDefault()].Any(c => c.R == nRed && c.G == nGreen && c.B == nBlue))
								colourDictionary[caNearbyColours.FirstOrDefault()].Add(Color.FromArgb(255, nRed, nGreen, nBlue));
						}
						else
							colourDictionary.Add(Color.FromArgb(255, nRed, nGreen, nBlue), new List<Color>());
					}
					else
						colourDictionary.Add(Color.FromArgb(255, nRed, nGreen, nBlue), new List<Color>());
				}
			}
		}
		finally
		{
			bitmap.UnlockBits(bitmapData);
		}
		using (Bitmap colourBitmap = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat))
		{
			using (Graphics g = Graphics.FromImage(colourBitmap))
			{
				for (int h = 0; h < colourBitmap.Height; h++)
				{
					for (int w = 0; w < colourBitmap.Width; w++)
					{
						Color colour = bitmap.GetPixel(w, h);
						if (!colourDictionary.ContainsKey(colour))
						{
							Color keyColour = colourDictionary.Keys.FirstOrDefault(k => colourDictionary[k].Any(v => v == colour));
							colourBitmap.SetPixel(w, h, keyColour);
						}
						else
							colourBitmap.SetPixel(w, h, colour);
					}
				}
			}
			colourBitmap.Save(@"OutputPath", System.Drawing.Imaging.ImageFormat.Png);
		}
	}
