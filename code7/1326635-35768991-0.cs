    string appFolder = Path.GetDirectoryName(@"C:\DEV\root\project01\bin\release\project01.exe");
    string configPath = null;
    while (true)
    {
        Console.WriteLine(appFolder);
        if (Directory.EnumerateFiles(appFolder, "*application.config", SearchOption.AllDirectories).Any(f => abc(f)))
        {
            configPath = appFolder + "\\application.config";
            break;
        }
        else appFolder = Path.GetDirectoryName(appFolder);
        if (appFolder.Length < 4) // "C:\" don't search root drive
        {
            break;
        }
    }
    if (configPath != null)
        Console.WriteLine(configPath);
    ---------------------------
    static bool abc(string f)
    {
        return f.ToLower().EndsWith("\application.config");
    }
