    ProcessStartInfo startinfo = new ProcessStartInfo();
    startinfo.FileName = @"f:\plink.exe";
    startinfo.Arguments = "-ssh abc@x.x.x.x -pw abc123";
    Process process = new Process();
    process.StartInfo = startinfo;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardInput = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    process.StandardInput.WriteLine("ls -ltr /opt/*.tmp");
    while (!process.StandardOutput.EndOfStream)
    {
        string line = process.StandardOutput.ReadLine();
    }
    process.StandardInput.WriteLine("exit");
    process.WaitForExit();
    Console.ReadKey();
