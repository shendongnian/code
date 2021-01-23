     private static FileSystemWatcher fw;
     static void Main(string[] args)
           {
                fw = new FileSystemWatcher(@"D:\Folder_Watch");
                fw.IncludeSubdirectories = true;
                fw.NotifyFilter = NotifyFilters.LastAccess |
         NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                fw.Created += fw_Created;
                fw.Changed += fw_Created;
                fw.Renamed += fw_Created;
                fw.Filter = "*.*";
                fw.EnableRaisingEvents = true;
    
                new System.Threading.AutoResetEvent(false).WaitOne();        
            }
     static void fw_Created(object sender, FileSystemEventArgs e)
            {
                try
                {
                    fw.EnableRaisingEvents = false;
                    //Your Code
                }
                finally
                {
                    fw.EnableRaisingEvents = true;
                }
            }
