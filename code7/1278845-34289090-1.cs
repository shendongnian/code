    static void Main(string[] args)
	{
		processDirectory(@"c:\temp");
	}
	
	private static void processDirectory(string startLocation)
	{
		foreach (var directory in Directory.GetDirectories(startLocation))
		{
			processDirectory(directory);
			
			if (Directory.GetDirectories(directory).Length == 0))
			{
				bool delete = false;
				
				var files = Directory.GetFiles(directory);
				// This will delete the directory if it contains a file with the Extension
				// of .dvr, regardless if there are other files in there. Might be something you want to change.
				for (int i = 0; i < files.Length && !delete; i++)
				{
					delete = files[i].Extension.Equals(".dvr", StringComparison.OrdinalIgnoreCase);
				}
				
				if (delete)
				{
                    // Recursive must be set to true in order to
                    // delete files and sub-directories in the folder.
                    // This folder will not have any sub-directories
                    // so it's only used to delete the files.
					Directory.Delete(directory, /*recursive*/ true);
				}
			}
		}
	}
