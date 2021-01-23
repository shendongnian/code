    private const string FilePath = "Logs/WZCLogs/";
    public void MakeLog(string text)
    {
         string directory = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, FilePath);
         Directory.CreateDirectory(directory); // no need to check if it exists
                
         string logFile = Path.Combine(directory, DateTime.Now.ToString("ddMMyyyy") + ".txt");
         if (!File.Exists(logFile))
         {
             FileStream f = File.Create(logFile);
             f.Close();
         }
    
         using (StreamWriter sw = new StreamWriter(logFile, true))
         {
             sw.WriteLine(text);
             sw.Close();
         }
    }
