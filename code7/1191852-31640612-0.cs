	Bitmap copy;
	using (DataStream stream = Surface.ToStream(surface, ImageFileFormat.Bmp))
	{
		Bitmap orig = new Bitmap(stream);
		copy = new Bitmap(orig);
	}
	// Able to use copy after stream is disposed
