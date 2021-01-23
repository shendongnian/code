    var process = new System.Diagnostics.Process();
    process.StartInfo.FileName = "Updater.exe";
    process.Start();
    process.WaitForExit();
    System.IO.File.Delete("Updater.exe");
