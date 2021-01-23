    class Program    {
        static void Main(string[] args)
        {
            String Temp = System.IO.Path.GetTempPath();
            String tmpDir = Temp + @"tmp\";
            String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
            String filePath = Path.Combine(Extension.AssemblyDirectory, fileName);
            String tempFilePath = Path.Combine(tmpDir, fileName);
            
            if (!Directory.Exists(tmpDir)) { Directory.CreateDirectory(tmpDir); }
            if (!(string.Equals(filePath, tempFilePath))) // if the application is not running at temp folder
            {
                if (!(File.Exists(tempFilePath))) // if the application does not exist at temp folder
                {
                    ext.initFile();
                }
                else if (File.Exists(tempFilePath)) // if the application already exists at temp folder
                {
                    File.Delete(tempFilePath);
                    ext.initFile();
                }
            }
            else if (string.Equals(filePath, tempFilePath)) // if the application is running at temp folder
            {
                    //main code
            }
        }
    }
