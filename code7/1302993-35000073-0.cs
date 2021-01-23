	Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
	IntPtr ptr = bmpData.Scan0;
	for (var y = 0; y < channelId.Length; y++)
	{
		var scanLineSize = channelId[y].Count*4;
		var rgb = new byte[scanLineSize];
		int idx = 0;
        // Convert the whole scanline
		foreach (var id in channelId[y])
		{
			rgb[idx] = rgb[idx+1] = rgb[idx+2] = (byte)(id*255/1000);
			rgb[idx+3] = 255;
			idx += 4;
		}
        // And copy it in one pass
		System.Runtime.InteropServices.Marshal.Copy(rgb, 0, ptr, scanLineSize);
		ptr += bmpData.Stride;
	}
	bmp.UnlockBits(bmpData);
