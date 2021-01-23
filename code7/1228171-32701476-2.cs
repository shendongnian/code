     public static Watchfile() 
     {
             FileSystemWatcher watch = new FileSystemWatcher();
             watch.Path = @"C:\";
             watch.Filter = "log.txt";
             watch.NotifyFilter = NotifyFilters.LastAccess |    
             NotifyFilters.LastWrite; 
            watch.Changed += new FileSystemEventHandler(OnChanged);
           watch.EnableRaisingEvents = true;
      }
     private static void OnChanged(object source, FileSystemEventArgs e)
     {
       
       
        string line;
             if (e.FullPath == @"C:\log.txt")
             {
                 Regex _regex = new Regex(@"\[[\w :]+\] <SYSTEMWIDE_MESSAGE>: \w+ has been defeated by a group of hardy adventurers! Please join us in congratulating \w+ along with everyone else who participated in this achievement!");
                 System.IO.StreamReader file =
                           new System.IO.StreamReader(@"C:\log.txt");
                 while ((line = file.ReadLine()) != null)
                 {
                     Match match = _regex.Match(line);
                     if (match.Success)
                     {
                         //Match Found
                     }
                     
                 }
                 file.Close();
             }
        
     }
