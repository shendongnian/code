    var logPath = System.IO.Path.GetTempFileName();
    using (var writer = File.CreateText(logPath))
    {
        writer.WriteLine("log message"); //or .Write(), if you wish
    }
