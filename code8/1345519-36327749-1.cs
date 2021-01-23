    private const string FilePath = "Logs/WZCLogs/";
    public void MakeLog(string text)
    {
        string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, FilePath);
        Directory.CreateDirectory(directory);
                
        string logFile = Path.Combine(directory, DateTime.Now.ToString("ddMMyyyy") + ".txt");
        File.AppendAllText(logFile, text + Environment.NewLine);
    }
