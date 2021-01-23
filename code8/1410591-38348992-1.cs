    string path = Server.MapPath("~/Views"); //path to start searching.
    if (Directory.Exists(path))
    {
        ProcessDirectory(path);
    }
    //Loop through each file and directory of provided path.
    public void ProcessDirectory(string targetDirectory)
    {
         // Process the list of files found in the directory.
         string[] fileEntries = Directory.GetFiles(targetDirectory);
         foreach (string fileName in fileEntries)
         {
              string found = ProcessFile(fileName);
         }
         //Recursive loop through subdirectories of this directory.
         string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
         foreach (string subdirectory in subdirectoryEntries)
         {
              ProcessDirectory(subdirectory);
         }
    }
    //Get contents of file and search specified text.
    public string ProcessFile(string filepath)
    {
        string content = string.Empty;
        string strWordSearched = "test";
 
        using (var stream = new StreamReader(filepath))
        {
             content = stream.ReadToEnd();
             int index = content.IndexOf(strWordSearched);
             if (index > -1)
             {
                  return Path.GetFileName(filepath);
             }
         } 
     }
