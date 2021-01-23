    using System.IO;
    var logPath = Path.GetTempFileName();
    using (var writer = File.CreateText(logPath))
    {
        writer.WriteLine("log message"); //or .Write(), if you wish
    }
