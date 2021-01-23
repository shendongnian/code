    Bitmap myBitmap = new Bitmap ("input.png");
	int skipX = 12;
	int skipY = 12;
	int detectedDots = 0;
	for (int x = 0; x < myBitmap.Width; x += skipX) {
		for (int y = 0; y < myBitmap.Height; y += skipY) {
			Color pixelColor = myBitmap.GetPixel (x, y);
			if (pixelColor.R + pixelColor.G + pixelColor.B == 0) {
				myBitmap.SetPixel (x, y, Color.Red);
				detectedDots++;
			}
		}
	}
	myBitmap.Save ("output.png");
	Console.WriteLine (detectedDots + " dots detected");
