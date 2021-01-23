    private const string FileNameAndLocation = "yourfilename.txt";
    private void AppClosing()
    {
        using (StreamWriter sw = new StreamWriter(FileNameAndLocation))
        {
            sw.WriteLine(StartTime.ToString());
        }
    }
    
    private void AppStarting()
    {
        if (!File.Exists(FileNameAndLocation))
        {
            StartTime = DateTime.Now;
            return;
        }
    
        using (StreamReader sr = new StreamReader(FileNameAndLocation))
        {
            var line = sr.ReadLine();
            StartTime = Convert.ToDateTime(line);
        }
    }
