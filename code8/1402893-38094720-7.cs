	try
	{
		System.Drawing.Image img = (System.Drawing.Bitmap)System.Drawing.Image.FromFile("myimage.png");
	}
	catch (OutOfMemoryException ex)
	{
		Console.WriteLine("Error loading image...");
	}
