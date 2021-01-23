    if (Directory.Exists(destDirName))
    {
     string dirToSearch = "App_data_payroll";
     var searchDir = Directory.GetDirectories(@"D:\").Where(x => new DirectoryInfo(x).Name == dirToSearch).ToList();
     string copyToLocation = @"E:\newDir";
     if (searchDir.Count > 0)// True if found
       {
         foreach (var file in Directory.GetFiles(searchDir[0]))// will iterate if it has files
          {
             File.Copy(file, copyToLocation, true); 
          }
       }
     else
       {
        // show message directory not found
       }
    }
           
