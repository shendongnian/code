    class Extension
    {
        String Temp = System.IO.Path.GetTempPath();
        String tmpDir = Temp + @"tmp\";
        String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
        String filePath = Path.Combine(Extension.AssemblyDirectory, fileName);
        String tempFilePath = Path.Combine(tmpDir, fileName);
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static void initFile()
        {
                File.Copy(filePath, tempFilePath);
                Process.Start(tempFilePath);
                System.Environment.Exit(0);
        }
     }
