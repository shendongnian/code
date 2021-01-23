	try
	{
		// Using System.Drawing
		Image img = (Bitmap)Image.FromFile("myimage.png");
	}
	catch (OutOfMemoryException ex)
	{
		// Handle the exception...
	}
