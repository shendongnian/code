    var files = GetFiles(@"C:/tmp/", @"C:/tmp/");
    return;
    
     public static List<string> GetFiles(string path, string basePath)
        {
          var files = System.IO.Directory.GetFiles(path).ToList().Select(m => m.Replace(basePath, "")).ToList();
          foreach (var directory in System.IO.Directory.GetDirectories(path))
          {
            files.AddRange(GetFiles(directory, basePath));
          }
          files = files.Select(m => m.Replace(basePath, "")).ToList();
          return files;
        }
