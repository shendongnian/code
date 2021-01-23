    	public static unsafe SharpDX.WIC.Bitmap CreateWICBitmapFromGDI(
			System.Drawing.Bitmap gdiBitmap)
		{
			var wicFactory = new ImagingFactory();
			var wicBitmap = new SharpDX.WIC.Bitmap(
				wicFactory, gdiBitmap.Width, gdiBitmap.Height,
				SharpDX.WIC.PixelFormat.Format32bppBGRA, 
				BitmapCreateCacheOption.CacheOnLoad);
			System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
				0, 0, gdiBitmap.Width, gdiBitmap.Height);
			var btmpData = gdiBitmap.LockBits(rect,
				System.Drawing.Imaging.ImageLockMode.WriteOnly,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			byte* pGDIData = (byte*)btmpData.Scan0;
			using (BitmapLock bl = wicBitmap.Lock(BitmapLockFlags.Write))
			{
				byte* pWICData = (byte*)bl.Data.DataPointer;
				for (int y = 0; y < gdiBitmap.Height; y++)
				{
					int offsetWIC = y * bl.Stride;
					int offsetGDI = y * btmpData.Stride;
					for (int x = 0; x < gdiBitmap.Width; x++)
					{
						pWICData[offsetWIC + 0] = pGDIData[offsetGDI + 0];	//R
						pWICData[offsetWIC + 1] = pGDIData[offsetGDI + 1];	//G
						pWICData[offsetWIC + 2] = pGDIData[offsetGDI + 2];	//B
						pWICData[offsetWIC + 3] = pGDIData[offsetGDI + 3];		//A
						offsetWIC += 4;
						offsetGDI += 4;
					}
				}
			}
			gdiBitmap.UnlockBits(btmpData);
			return wicBitmap;
		}
