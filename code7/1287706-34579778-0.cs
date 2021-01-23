	static void Main(string[] args) {
		string fileToFind = "*.jpg";
		var files = new List<string>();
		foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
			files.AddRange(FindDirectory(fileToFind, d.RootDirectory.FullName));
	}
	/// <summary>
	/// This function returns the full file path of the matches it finds. 
	///   1. It does not do any parameter validation 
	///   2. It searches recursively
	///   3. It eats up any error that occurs when requesting files and directories within the specified path
	///   4. Supports specifying wildcards in the fileToFind parameter.
	/// </summary>
	/// <param name="fileToFind">Name of the file to search, without the path</param>
	/// <param name="path">The path under which the file needs to be searched</param>
	/// <returns>Enumeration of all valid full file paths matching the file</returns>
	public static IEnumerable<string> FindDirectory(string fileToFind, string path) {
		// Check if "path" directly contains "fileToFind"
		string[] files = null;
		try {
			files = Directory.GetFiles(path, fileToFind);
		} catch { }
		if (files != null) {
			foreach (var file in files)
				yield return file;
		}
		// Check all sub-directories of "path" to see if they contain "fileToFInd"
		string[] subDirs = null;
		try {
			subDirs = Directory.GetDirectories(path);
		} catch { }
		if (subDirs == null)
			yield break;
		foreach (var subDir in subDirs)
			foreach (var foundFile in FindDirectory(fileToFind, subDir))
				yield return foundFile;
	}
