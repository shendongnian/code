    void Main()
    {
        string downloadLink = "dl", saveTo = "st", versionLink = "vl", versionSaveTo = "vst";
        Task taskExe = new Task(() => startDownload(downloadLink, saveTo));
        Task taskVersionTxt = taskExe.ContinueWith((t) => startDownload(versionLink, versionSaveTo));
        Task taskWriteVersion = taskVersionTxt.ContinueWith((t) => writeNewVersion());
        taskExe.Start();
    }
    void startDownload(string dl, string st)
    {
        Thread.Sleep(1000);
        ("Download done: " + dl + " " + st).Dump();
    }
    void writeNewVersion()    
    {
        "Version done".Dump();
    }
