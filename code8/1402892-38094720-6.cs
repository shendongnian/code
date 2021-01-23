	try
	{
		// Using System.Drawing.Image
		System.Drawing.Image img = (System.Drawing.Bitmap)System.Drawing.Image.FromFile("myimage.png");
	}
	catch (OutOfMemoryException ex)
	{
		// Handle the exception...
	}
