    using (Stream fs = System.IO.File.Open("test.txt", 
                                          FileMode.OpenOrCreate, 
                                          FileAccess.Write, 
                                          FileShare.ReadWrite)) 
    {
      using(var file = System.IO.StreamWriter(fs))
      {
         ...
      }
    }
