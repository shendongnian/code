    public string GetDirs(string path, string criteria)
    {
          // store all directory names
          var allDirs = new StringBuilder();
          string[] dir = Directory.GetDirectories(path, criteria);
          foreach (string directory in dir)
          {
              allDirs.AppendFormat("{0}\r\n", directory);
              // recursively call GetDirs again
              var subdirs = GetDirs(Path.Combine(path,directory), criteria);
              // store the subdirectory names
              allDirs.Append(subdirs);
          }
          // no more subdirs?
          if (dir.Length == 0) {
             // maybe show that dir?
             System.Diagnostics.Process.Start(path);
          }
          return allDirs.ToString();
    }
