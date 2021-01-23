    //Group files by month. Later you can skip some groups if needed
	var fileGroups = directory.GetFiles()
		.GroupBy(file => file.LastWriteTime.Month);
	foreach (var fileList in fileGroups)
	{
		var year = fileList.First().LastWriteTime.Year;
		var month = fileList.First().LastWriteTime.Month;
		var newFolderPath = year.ToString() + month.ToString();
		var destinationDirec = System.IO.Directory.CreateDirectory(directory + newFolderPath);
		//move files
		foreach (var file in fileList)
		{
			var path = Path.Combine(destinationDirec.FullName, file.Name);
			if (!File.Exists(path))
			{
				System.IO.File.Move(file.FullName, path);
			}
		}
	}
