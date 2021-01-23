    void DirSearch(string rootDirectory, string filesExtension, string textToSearch, BackgroundWorker worker, DoWorkEventArgs e)
     {
         List<string> filePathList = new List<string>();
         List<string> restrictedFiles = new List<string>();
         // Other Inits
         try
         {
             filePathList = Directory.GetFiles(rootDirectory, filesExtension, SearchOption.AllDirectories).ToList();
         }
         catch (Exception err)
         {
             string ad = err.ToString();
         }
         foreach (string file in filePathList)
         {
             try
             {
                 // Code before
                 int var = File.ReadAllText(file).Contains(textToSearch) ? 1 : 0;
                 // it will throw exception if it is not accessible
                 // Your code after
             }
             catch (Exception)
             {
                 restrictedFiles.Add(file);
                 continue;
             }
         }
         // restrictedFiles will contains all restricted files @ the end of iteration
     }
 
