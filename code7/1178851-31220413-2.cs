    List<TimeLogData> data = new List<TimeLogData>();
    TimeLogLineParser lineParser = new TimeLogLineParser();
    foreach(string line in File.ReadlAllLines("...path..."))
    {
    	data.Add(lineParser.ParseLine(line));
    }
