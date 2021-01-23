    private void button1_Click(object sender, EventArgs e)
     {
        CheckDirectory("path_to_my_mother_directory");
    }
    
        private void CheckDirectory(string targetDirectory)
        {
            MyLog.LogInfo("Check directory", string.Format("Checking for files in {0} directory", targetDirectory));
            var fileEntries = Directory.GetFiles(targetDirectory);
            foreach (var fileName in fileEntries)
                ProcessFile(fileName);
        
            // Check subfolders
            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (var subdirectory in subdirectoryEntries)
                CheckDirectory(subdirectory);
        }
        
        private void ProcessFile(string path)
        {
            MyLog.LogInfo("File Found", string.Format("File '{0}' found", path));
        
            var Fileinfo = new FileInfo(path);
            if (Fileinfo.Exists && extentionFilesType.Contains(Fileinfo.Extension))
            {
                MyLog.LogInfo("Check extension file", string.Format("File has a searched extension ({0})", Fileinfo.Extension));
                FilesToInsert.Add(Fileinfo);
            }
            else
            {
                MyLog.LogInfo("Check extension file", "File doesn't has a searched extension");
            }
        }
