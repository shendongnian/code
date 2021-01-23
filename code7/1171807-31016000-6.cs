	var cts = new CancellationTokenSource();
	try
	{
		Task.WaitAll(SaveFilesAsync(@"C:\Some\Path", files, cts.Token));
	}
	catch (Exception)
	{
		Debug.Print("SaveFilesAsync Exception");
	}
	finally
	{
		cts.Dispose();
	}
