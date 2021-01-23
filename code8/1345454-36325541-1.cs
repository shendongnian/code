    var processInfo = new System.Diagnostics.ProcessStartInfo("ffmpeg.exe", command);
    processInfo.UseShellExecute = false;
    processInfo.CreateNoWindow = false;/////////////////Changed here
    processInfo.WorkingDirectory = System.Environment.CurrentDirectory;
    processInfo.ErrorDialog = true;
    processInfo.RedirectStandardOutput = true;
    processInfo.RedirectStandardError = true;
    
    _StreamerProcess = new System.Diagnostics.Process();
    _StreamerProcess.StartInfo = processInfo;
    _StreamerProcess.EnableRaisingEvents = true;
    _StreamerProcess.OutputDataReceived += _StreamerProcess_OutputDataReceived;
    _StreamerProcess.ErrorDataReceived += _StreamerProcess_ErrorDataReceived;
    _StreamerProcess.Start();
    _StreamerProcess.BeginOutputReadLine();
    _StreamerProcess.BeginErrorReadLine();
