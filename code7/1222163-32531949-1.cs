    using(FileStream fs = new FileStream(Path.Combine(Folder, LogFile),
                                          FileMode.OpenOrCreate,
                                          FileAccess.Write,
                                          FileShare.ReadWrite))
    {
       using(System.IO.StreamWriter file = new System.IO.StreamWriter(fs))
       {
          while(!token.IsCancellationRequested)
          {          
             file.WriteLine("bla bla bla");
             file.Flush();
          }
       }
    }
