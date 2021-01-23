    private static void watcher_FileCreated(object sender, FileSystemEventArgs e)
    {
      string strFileExt = getFileExt(e.FullPath); 
    
      // filter file types 
      if (Regex.IsMatch(strFileExt, @"\.png|\.jpg", RegexOptions.IgnoreCase)) 
      { 
          //here Process the image file 
      }
    } 
