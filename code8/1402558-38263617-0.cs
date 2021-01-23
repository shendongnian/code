	public unsafe Image ResizeImage(Bitmap img, int width, int height)
	{
		var stopwatch = Stopwatch.StartNew();
		var imgBits = img.LockBits(new Rectangle(Point.Empty, img.Size), ImageLockMode.ReadOnly, img.PixelFormat);
		
		Bitmap b = new Bitmap(width, height);
		var bBits = b.LockBits(new Rectangle(Point.Empty, b.Size), ImageLockMode.WriteOnly, b.PixelFormat);
		for (int j = 0; j < height; j++)
		{
			var imgJ = j * img.Height / height;
			for (int i = 0; i < width; i++)
			{
				var imgI = i * img.Width / width;
				var imgPointer = (byte*)imgBits.Scan0 + imgJ * imgBits.Stride + (imgI >> 3);
				var mask = (byte)(0x80 >> (imgI & 0x7));
				var imgPixel = (uint)(*imgPointer & mask);
				var bPointer = (uint*)bBits.Scan0 + j * bBits.Width + i;
				*bPointer = imgPixel > 0 ? 0x00FFFFFF : 0xFF000000;
			}
		}
		img.UnlockBits(imgBits);
		b.UnlockBits(bBits);
		stopwatch.Stop();
		textBox1.AppendText("Resize to " + width + " x " + height + " within " + stopwatch.ElapsedMilliseconds + "ms\r\n");
		return b;
	}
