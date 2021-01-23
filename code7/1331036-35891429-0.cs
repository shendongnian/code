        List<string> lstfilepaths = new List<string>();
        public static void ProcessDirectory(string targetDirectory) 
        {
          // Process the list of files found in the directory.
 
           string [] fileEntries = Directory.GetFiles(targetDirectory);
           foreach(string fileName in fileEntries) // included as per your logic
           {
                if(fileName == "do1.bat")
                  {
                     ProcessFile(fileName);
                  }
           }
        // Recurse into subdirectories of this directory.
            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries)
                 ProcessDirectory(subdirectory);
         }
         public static void ProcessFile(string path) 
           {
        	lstfilepaths.Add(path);    
           }
