    public static void MoveFiles(string sourceDir, string destDir) 
    {
        string[] files = Directory.GetFiles(sourceDir);
		
		foreach(string file in files)
		{
			string dest = file.Replace(sourceDir, destDir);
			
			if (!File.Exists(dest))
				File.Move(file, dest);			
		}
    }
