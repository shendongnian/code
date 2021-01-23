    var cppProcess = new Process();
    cppProcess.StartInfo = new ProcessStartInfo
    {
        FileName = "YourCppApp.exe",
        UseShellExecute = false,
        RedirectStandardOutput = true,
    };
    cppProcess.Start();
    using (var cppOutput = new BinaryReader(cppProcess.StandardOutput.BaseStream))
        while (!cppProcess.StandardOutput.EndOfStream)
        {
            var buffer = new byte[4096];
            int bytesRead= cppOutput.Read(buffer, 0, buffer.Length);
            // Process the buffer...
        }
