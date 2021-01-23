    var cppProcess = new Process();
    cppProcess.StartInfo = new ProcessStartInfo
    {
        FileName = "ConsoleApplication3.exe",
        UseShellExecute = false,
        RedirectStandardOutput = true,
    };
    cppProcess.OutputDataReceived += (sender, arg) =>
    {
        Console.WriteLine("Received: {0}", arg.Data);
    };
    cppProcess.Start();
    using (var cppOutput = new BinaryReader(cppProcess.StandardOutput.BaseStream))
        while (!cppProcess.StandardOutput.EndOfStream)
        {
            var buffer = new byte[4096];
            int bytesRead= cppOutput.Read(buffer, 0, buffer.Length);
            // Process the buffer...
        }
