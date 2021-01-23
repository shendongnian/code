    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.UseShellExecute = false;
    process.ErrorDataReceived += Process_ErrorDataReceived;
    process.StartInfo.FileName = "CMD.exe";
    process.StartInfo.Arguments = AVRdudeCmd;
    process.Start();
    process.BeginErrorReadLine();
