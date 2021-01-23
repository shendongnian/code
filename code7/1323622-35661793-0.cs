    public FileStream OpenOrCreateFile(string path, FileAccess fileAccess, out bool isNewFileForAllPracticalPurposes)
    {
    	var fs = File.Open(path, FileMode.OpenOrCreate, fileAccess);
    	isNewFileForAllPracticalPurposes = (fs.Length == 0); // Consider any zero-byte file to be a "new" file.
    	return fs;
    }
