    using System.IO; 
    
    string[] files = Directory.GetFiles(dirName);
    
    foreach (string file in files)
    {
       FileInfo fi = new FileInfo(file);
       if (fi.CreationTime < DateTime.Now.AddDays(-15))
          fi.Delete();
    }
