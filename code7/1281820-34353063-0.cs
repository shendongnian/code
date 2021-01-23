    static void Main(string[] args)
    {
        string fileName = @"C:\path_to_project\bin\Debug\helloworld.exe";
        ProcessStartInfo info = new ProcessStartInfo(fileName);
        info.UseShellExecute = false;
        info.RedirectStandardInput = true;
        info.RedirectStandardOutput = true;
        info.RedirectStandardError = true;
        info.CreateNoWindow = true;
        StringBuilder outputBuilder = new StringBuilder();
        StringBuilder errorBuilder = new StringBuilder();
        Process process = new Process {StartInfo = info};
        process.OutputDataReceived += (sender, e) => outputBuilder.Append(e.Data);
        process.ErrorDataReceived += (sender, e) => errorBuilder.Append(e.Data);
        process.Start();
        process.BeginErrorReadLine(); // do this after process.Start()
        process.BeginOutputReadLine();
        process.WaitForExit();
        string error = errorBuilder.ToString();
        string returnvalue = outputBuilder.ToString();
        Console.WriteLine("Returned: {0}", returnvalue);
        Console.WriteLine("Error: {0}", error);
        Console.ReadLine();
    }
