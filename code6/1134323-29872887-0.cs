	var progress = new Progress<int>(value => progressBar.Value = value);
	await Task.Run(() =>
	{
		for (int i = 0; i < 100; i++)
		{
			((IProgress<int>)progress).Report(i);
			Thread.Sleep(100);
		}
	});
