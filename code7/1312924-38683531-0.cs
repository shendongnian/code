    var watcher = new BluetoothLEAdvertisementWatcher();
    var logPath = System.IO.Path.GetTempFileName();
    var logWriter = System.IO.File.CreateText(logPath);
    logWriter.WriteLine("Log message");
    logWriter.Dispose();
