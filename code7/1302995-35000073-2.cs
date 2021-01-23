	var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
	var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
	IntPtr ptr = bmpData.Scan0;
	int idx = 0;
	var rgb = new byte[channelId[0].Count * 4 * channelId.Length];
	foreach (var id in channelId.SelectMany(t => t))
	{
		rgb[idx] = rgb[idx+1] = rgb[idx+2] = (byte)(id*255/1000);
		rgb[idx+3] = 255;
		idx += 4;
	}
	System.Runtime.InteropServices.Marshal.Copy(rgb, 0, ptr, rgb.Length);
	bmp.UnlockBits(bmpData);
