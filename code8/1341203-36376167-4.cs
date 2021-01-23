    public bool CopyFiles(bool overwrite, string ipAddress, string sharename, string copySource)
    {
        bool result = false;
    
        string path = string.Format(@"\\{0}\{1}", ipAddress, sharename);
    
        if (!Directory.Exists(path))
        {
            mDisplay.appendToResults("Share doesn't exist \"" + path + "\" - are you sure it mapped ok?");
            return result;
        }
    
        if (!Directory.Exists(copySource))
        {
            mDisplay.appendToResults("Source folder \"" + copySource + "\" doesn't exist, need to specify where to copy file(s) from");
            return result;
        }
    
        recursivelyCopyContents(copySource, overwrite, path);
        result = true;
    
        return result;
    }
    private void recursivelyCopyContents(string sourceDirName, bool overwrite, string destDirName)
    {
        try
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
    
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
    
            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                mDisplay.appendToResults("Creating folder " + destDirName);
                Directory.CreateDirectory(destDirName);
            }
    
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
    
                string info = "Copying " + file.Name + " -> " + temppath;
    
    
                if (!overwrite && File.Exists(temppath))
                {
                    // Not overwriting - so show it already exists
                    mDisplay.appendToResults(info + " (already exists)");
                }
                else
                {
                    file.CopyTo(temppath, overwrite);
                    mDisplay.appendToResults(info + " OK");
                }
            }
    
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                recursivelyCopyContents(subdir.FullName, overwrite, temppath);
            }
        }
        catch (Exception ex)
        {
            mDisplay.showError("Problem encountered during copy : " + ex.Message);
        }
    }
