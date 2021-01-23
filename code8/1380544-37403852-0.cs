    private void ProcessFilesCSVFiles(string copyPath, string destinationPath)
    {
    	// first check if path exists
    	if (!Directory.Exists(copyPath))
    		// doesn't exist then exit, can't copy from something that doesn't exist
    		return;
    	var copyPathDirectory = new DirectoryInfo(copyPath);
    	// using the SearchOption.AllDirectories will search sub directories
    	var copyPathCSVFiles = copyPathDirectory.GetFiles("*.csv", SearchOption.AllDirectories);
    	for(var i = 0; i < copyPathCSVFiles.Length; i++)
    	{
    		// get the file
    		var csvFile = copyPathCSVFiles[i];
    		// read the csv file line by line
    		using (StreamReader sr = csvFile.OpenText())
    		{
    			string line = "";
    			while ((line = sr.ReadLine()) != null)
    			{
    				// use split to read the individual columns
    				// will fail if the text field has a comma in it
    				var split = line.Split(',');
    				Console.WriteLine(line);
    			}
    		}
    		// do other sql mojo here if needed
    
    		// move the files over to another place
    		var destinationFilePath = Path.Combine(destinationPath, csvFile.Name);
    		if (File.Exists(destinationFilePath))
    		{
    			File.Delete(destinationFilePath);
    		}
    		csvFile.MoveTo(destinationFilePath);
    	}
    }
