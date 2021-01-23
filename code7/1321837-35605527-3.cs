    public void ExtractDataFromLogFile(string logFilePath)
    {
        new Thread(() =>
        {
            var lines = File.ReadAllLines(logFilePath);
            foreach (var line in lines) ProcessFileContent(line);
            DP.Invoke(() => DataGrid.DataContext = _logEntries);
        }).Start();
    }
    private void ProcessFileContent(string line)
    {
        Match match = _regex.Match(line);
        if (match.Success)
        {
            LogEntry entry = new LogEntry()
            {
                LogLevel = match.Groups[1].ToString(),
                DateTime = DateTime.Parse(match.Groups[2].ToString(), new CultureInfo("de-DE")),
                Message = match.Groups[3].ToString()
            };
            _logEntries.Add(entry);
        }
    }
