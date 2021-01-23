    public void PrintFiles(string printerName, params string[] fileNames)
    {
        var files = String.Join(" ", fileNames);
        var command = String.Format("/C print /D:{0} {1}", printerName, files);
        var process = new Process();
        var startInfo = new ProcessStartInfo
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            FileName = "cmd.exe",
            Arguments = command
        };
        process.StartInfo = startInfo;
        process.Start();
    }
    //CALL
    PrintFiles("YourPrinterName", "file1.pdf", "file2.pdf", "file3.pdf");
