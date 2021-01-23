    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.UseShellExecute = false;
    startInfo.FileName = @rutaExe;
    startInfo.RedirectStandardOutput = true;
    startInfo.RedirectStandardError = true;
    startInfo.Arguments = String.Format(" -subject {0} -file {1}",
            request.asunto,
            Path.Combine(rutaTemp, request.archivo_firmado));
    var output = new StringBuilder();
    var err = new StringBuilder();
    using (Process exeProcess = new Process { StartInfo = startInfo })
    {
        exeProcess.OutputDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                output.Append(e.Data);
            }
        };
        exeProcess.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                err.Append(e.Data);
            }
        };
        exeProcess.Start();
        exeProcess.BeginOutputReadLine();
        exeProcess.BeginErrorReadLine();
        exeProcess.WaitForExit(1000 * 6 * 15);
    }
