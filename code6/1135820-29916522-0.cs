    private const string processName = @"c:\program files (x86)\pandoc\pandoc.exe";
    private const string args = @"-t markdown -r html5 -o ""{0}"" ""{1}""";
    
    public void Convert(Stream inputStream, Stream outputStream)
    {
        var process = new Process();
    
        var inputFilename = Path.GetTempFileName();
        var outputFilename = Path.GetTempFileName();
    
        using (var fileStream = File.Create(inputFilename))
        {
            inputStream.CopyTo(fileStream);
        }
    
        ProcessStartInfo psi = new ProcessStartInfo(processName, string.Format(args, outputFilename, inputFilename))
        {
            RedirectStandardOutput = true,
            RedirectStandardInput = true,
            UseShellExecute = false
        };
    
        process.StartInfo = psi;
        process.Start();
        process.WaitForExit();
    
        var bytes = File.ReadAllBytes(outputFilename);
        outputStream.Write(bytes, 0, bytes.Length);
    }
