    aProcess.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
    aProcess.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
    aProcess.BeginOutputReadLine();
    aProcess.BeginErrorReadLine();
    aProcess.WaitForExit();
