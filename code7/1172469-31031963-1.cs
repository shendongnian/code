    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.startInfo.RedirectStandardOutput = true;
    process.startInfo.RedirectStandardError = true;
    StreamReader stringBackFromProcess = process.StandardOutput;
    
    Debug.Write(stringBackFromProcess.ReadToEnd());
    // or
    
    Console.Write(stringBackFromProcess.ReadToEnd());
