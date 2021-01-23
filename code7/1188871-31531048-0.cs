    private void BtnProcess_Click(object sender, EventArgs e)
    {
      // create a list of source directories based on date range
      List<string> sourceDirectories = new List<string>();
      List<string> destDirectories = new List<string>();
      sourceDirectories.Add("C:\\Users\\Eric\\Desktop\\Dir1");
      sourceDirectories.Add("C:\\Users\\Eric\\Desktop\\Dir2");
      destDirectories.Add("C:\\Users\\Eric\\Desktop\\Dest1");
      destDirectories.Add("C:\\Users\\Eric\\Desktop\\Dest2");
      // create a list of source files to copy and destination
      foreach (var path in sourceDirectories)
      {
        if (!Directory.Exists(path))
        {
          //Error message here if path does not exist or continue with the next path
          continue;
        }
        try
        {
          IEnumerable<string> paths = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
          DirectoryInfo destPathInfo = Directory.CreateDirectory(destDirectories[0]); // create the destination folder
          if (destPathInfo.Exists)
          {
            foreach (var p in paths)
            {
              string destination = System.IO.Path.Combine(destDirectories[0], System.IO.Path.GetFileName(p));
              System.IO.File.Copy(p, destination);
            }
            destDirectories.RemoveAt(0);
          }
        }
        catch (Exception ex)
        {
        }
      }
    }
