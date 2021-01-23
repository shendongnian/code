    Bitmap myBitmap = new Bitmap("input.png");
	int skipX = 18;
	int skipY = 18;
	int detectedDots = 0;
	for (int x = 0; x < myBitmap.Width; x+= skipX) {
		for (int y = 0; y < myBitmap.Height; y+= skipY) {
			Color pixelColor = myBitmap.GetPixel(x, y);
			if(pixelColor.R + pixelColor.G + pixelColor.B == 0)
				detectedDots++;
		}
	}
	Console.WriteLine(detectedDots+" dots detected");
