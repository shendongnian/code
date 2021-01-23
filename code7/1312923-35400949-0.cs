    var watcher = new BluetoothLEAdvertisementWatcher();
    var logPath = System.IO.Path.GetTempFileName();
    var logFile = System.IO.File.Create(logPath);
    var logWriter = new System.IO.StreamWriter(logFile);
    logWriter.WriteLine("Log message");
    logWriter.Dispose();
