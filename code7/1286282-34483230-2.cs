    Shell s = new Shell();
    var folder = s.NameSpace( <path_to_your_zip> );
        
    foreach (FolderItem2 item in folder.Items())
    {
      string oItemName = Path.GetFileName(item.Path);
      
      try
      {
                    
        string oTargetFile = Path.Combine(Path.GetTempPath(), oItemName);
        if (File.Exists(oTargetFile))
          File.Delete(oTargetFile);
        Folder target = s.NameSpace(Path.GetTempPath());
        target.CopyHere(item, 4);
        var info = FileVersionInfo.GetVersionInfo(oTargetFile);
        if (File.Exists(oTargetFile))
          File.Delete(oTargetFile);
        Console.WriteLine(oItemName + "'s version is: " + info.FileVersion);
      }
      catch (Exception e)
      { 
        Console.WriteLine(oItemName + ": Unable to obtain version info.\n" + e.Message);  
      }
    }
