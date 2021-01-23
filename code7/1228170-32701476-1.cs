     public static Watchfile() 
     {
             FileSystemWatcher watch = new FileSystemWatcher();
             watch.Path = "YourFilePath";
             watch.Filter = "logfile.txt";
             watch.NotifyFilter = NotifyFilters.LastAccess |    
             NotifyFilters.LastWrite; 
            watch.Changed += new FileSystemEventHandler(OnChanged);
           watch.EnableRaisingEvents = true;
      }
     private static void OnChanged(object source, FileSystemEventArgs e)
     {
        if(e.FullPath == YourPath)
        {
                Regex _regex=new Regex(@"\[[\w :]+\] <SYSTEMWIDE_MESSAGE>: 
                           \w+ has been defeated by a group of hardy adventurers! Please join
                           us in congratulating \w+ along with everyone else who participated
                           in this achievement!")
     System.IO.StreamReader file = 
               new System.IO.StreamReader(@"YourLogFile.txt");
         while((line = file.ReadLine()) != null)
         {
             Match match=_regex.Match(line);
             if(match.Success)
             {
            
               //Match Found
              }
            file.Close();
          }
        }
     }
