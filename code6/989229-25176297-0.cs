    var fileInfo = new FileInfo(sourcePath);
    
    // Check if the file already exists.
	if (!fileInfo.Exists)
		fileInfo.MoveTo(pathTo);
	else
	{
		var file = Directory.GetFiles(pathTo, filename + ".1").FirstOrDefault();
		if (file == null)
		{
			fileInfo.MoveTo(pathTo + ".1");
		}
		else
		{
			// Get all files with the same name.
			string[] getSourceFileNames = Directory.GetFiles(Path.GetDirectoryName(pathTo)).Where(s => s.Contains(filename)).ToArray();
			// Retrieve the last index.
			int lastIndex = 0;
			foreach (string s in getSourceFileNames)
			{
				int currentIndex = 0;
				int.TryParse(s.Split('.').LastOrDefault(), out currentIndex);
				if (currentIndex > lastIndex)
					lastIndex = currentIndex;
			}
			// Do something with the last index.
            lastIndex++;
			fileInfo.MoveTo(pathTo + lastIndex);
		}
	}
