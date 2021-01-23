	static void Main(string[] args)
	{
		System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
		worker.ProgressChanged += Worker_ProgressChanged;
		worker.DoWork += Worker_DoWork;
		//Do work
		worker.RunWorkerAsync();
	}
	private static void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
	{
		//Get Values
		var source = null;
		var destinations = null;
		//CopyData Method
		setProgressBar(sources, destinations);
		foreach (var source in sources)
		{
			foreach (var dirPath in System.IO.Directory.GetDirectories(source.directory, "*", SearchOption.AllDirectories))
			{
				foreach (var destination in destinations)
				{
					logger(dirPath);
					System.IO.Directory.CreateDirectory(dirPath.Replace(source.directory, destination.directory));
					//Increase Value by 1
					(sender as System.ComponentModel.BackgroundWorker).ReportProgress(1);
				}
			}
			foreach (var newPath in System.IO.Directory.GetFiles(source.directory, "*.*", SearchOption.AllDirectories))
			{
				foreach (var destination in destinations)
				{
					logger(newPath);
					File.Copy(newPath, newPath.Replace(source.directory, destination.directory), true);
					//Increase Value by 1
					(sender as System.ComponentModel.BackgroundWorker).ReportProgress(1);
				}
			}
		}
	}
	private static void Worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
	{
		if (e.ProgressPercentage == 1)
		{
			//If Value gets higher than Maximum it will cause an Exception
			if (progress.Value < progress.Maximum)
				progress.Value += 1;
		}
	}
	private static void setProgressBar(List sources, List destinations)
	{
		progress.Value = 0;
		progress.Maximum = 0;
		foreach (var source in sources)
		{
			foreach (var dirPath in System.IO.Directory.GetDirectories(source.directory, "*", SearchOption.AllDirectories))
			{
				//Simplified
				progress.Maximum += destinations.Count;
			}
			foreach (var newPath in System.IO.Directory.GetFiles(source.directory, "*.*", SearchOption.AllDirectories))
			{
				//Simplified
				progress.Maximum += destinations.Count;
			}
		}
	}
