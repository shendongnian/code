           public void DeleteDirectoryFiles(DirectoryInfo dirInfo) 
                  {
                      foreach(FileInfo files in dirInfo.GetFiles()) 
                          {
                             try
                                {
                                files.Delete(); 
                                }
                             catch(IOException ex)
                                {
                                      // code to handle
                                }
                          }
    
                  }
