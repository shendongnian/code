    string path = Server.MapPath("~/Views");
           if(Directory.Exists(path)) 
            {
                ProcessDirectory(path);
            }
     public  void ProcessDirectory(string targetDirectory) 
     {
        // Process the list of files found in the directory.
        string [] fileEntries = Directory.GetFiles(targetDirectory);
        foreach(string fileName in fileEntries)
       {
             string found =  ProcessFile(fileName);
       }
        // Recurse into subdirectories of this directory.
        string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach(string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
    public string ProcessFile(string filepath) 
    {
        string content = string.Empty;
        string strWordSearched = "test";
            try
            {
                using (var stream = new StreamReader(filepath))
                {
                    content = stream.ReadToEnd();
                   int index=    content.IndexOf(strWordSearched) ;
                   if(index > -1){
                    return Path.GetFileName(filepath);
                   }
 
    }   
        }
