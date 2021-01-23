    static string FindConfig()
    {
        string appFolder = Path.GetDirectoryName(@"C:\DEV\root\project01\bin\release\project01.exe");
        string configPath = null;
        while (true)
        {
            Console.WriteLine(appFolder);
            string[] files = Directory.GetFiles(appFolder, "*application.config", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.ToLower().EndsWith(@"\application.config"))
                {
                    return file;
                }
            }
            appFolder = Path.GetDirectoryName(appFolder);
            if (appFolder.Length < 4) // "C:\" don't search root drive
            {
                break;
            }
        }
        return configPath;
    }
