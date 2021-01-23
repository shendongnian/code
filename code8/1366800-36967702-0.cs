		Bitmap ImageFromArray(byte[] arr, int width, int height)
		{
			var output = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
			var rect = new Rectangle(0, 0, width, height);
			var bmpData = output.LockBits(rect,ImageLockMode.WriteOnly, output.PixelFormat);
			var ptr = bmpData.Scan0;
			if (bmpData.Stride != width)
				throw new InvalidOperationException("Cant copy directly if stride mismatches width, must copy line by line");
			Marshal.Copy(arr, 0, ptr, width*height);
			output.UnlockBits(bmpData);
			var palEntries = new Color[256];
			var cp = output.Palette;
			for (int i = 0; i < 256; i++)
				cp.Entries[i] = Color.FromArgb(i, i, i);
			output.Palette = cp;			
			return output;
		}
