       public static FileAttributes RemoveAttribute (FileAttributes att, FileAttributes attToRemove)
       {
            return att &  ~attToRemove;
        }
      
    public void DeleteProfileFolder(string file)
     {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProvessWindowsStyle.Hiddenl
        startInfo.FileName = "cmd";
        startInfo.Arguments = "/C rd /S /Q  \"" + file + "\"";
        process.StartInfo = startInfo;
       process.Start();
       process.WaitForExit();
    }
    public void Deletes(DirectoryInfo baseDir)
    {  
         if(! baseDir.Exists)
           return;
       var Dirs = Directory.EnumerateDirectories(baseDir.ToString(),"*.*",SearchOption.TopDirectoryOnly);
       var files = Directory.EnumerateFiles(baseDir.ToString(),"*.*",SearchOption.TopDirectoryOnly);
        
       foreach(var dir in Dirs)
       {
             DeleteProfileFolder(dir);
        } 
      foreach(var file in files)
     {
          FileAttributes att = File.GetAttributes(f);
          if((att & FileAttributes.Hidden) == FileAttribute.Hidden)
          {  
                att = RemoveAttribute(att, FileAttributes.Hidden);
                File.SetAttributes(file , att);
                File.SetAttributes(File, FileAttributes.Normal)
            }
       File.Delete(file);
      }
     
    }
