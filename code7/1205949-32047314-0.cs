	const int CONCURRENCY_LEVEL = 15;
	Uri [] urls = …;
	int nextIndex = 0;
	var imageTasks = new List<Task<Bitmap>>();
	while(nextIndex < CONCURRENCY_LEVEL && nextIndex < urls.Length)
	{
		imageTasks.Add(GetBitmapAsync(urls[nextIndex]));
		nextIndex++;
	}
	while(imageTasks.Count > 0)
	{
		try
		{
			Task<Bitmap> imageTask = await Task.WhenAny(imageTasks);
			imageTasks.Remove(imageTask);
			Bitmap image = await imageTask;
			panel.AddImage(image);
		}
		catch(Exception exc) { Log(exc); }
		if (nextIndex < urls.Length)
		{
			imageTasks.Add(GetBitmapAsync(urls[nextIndex]));
			nextIndex++;
		}
	}
