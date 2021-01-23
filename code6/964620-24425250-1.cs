    private static Stream lockFile;
    public static void Main()
    {
      try
      {
        try
        {
          lockFile = File.OpenWrite(@"\\server\folder\lock.txt");
        }
        catch (IOException e)
        {
          int err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
          if (err == 32)
          {
            MessageBox.Show("App already running on another computer");
            return;
          }
          throw; //You should handle it properly...
        }
    
        //... run the apps
      }
      finally
      {
        if (lockFile != null)
          lockFile.Dispose();
      }
    }
