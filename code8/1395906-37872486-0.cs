    public virtual Task<bool> ExecuteAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        string exe1 = Spec.GetExecutablePath1();
        string exe2 = Spec.GetExecutablePath2();
        string args1 = string.Format("--input1={0} --input2={1}", Input1, Input2);
        string args2 = string.Format("--input1={0} --input2={1}", Input1, Input2);
    
        try
        {
            var process1 = new Process
            {
                EnableRaisingEvents = true,
                StartInfo =
                {
                    UseShellExecute = false,
                    FileName = exe1,
                    Arguments = args1,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDir = CaseDir
                }
            };
            var process2 = new Process
            {
                EnableRaisingEvents = true,
                StartInfo =
                {
                    UseShellExecute = false,
                    FileName = exe2,
                    Arguments = args2,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDir = CaseDir
                }
            };
            process1.Exited += (sender, arguments) =>
            {
                if (process1.ExitCode != 0)
                {
                    string errorMessage = process1.StandardError.ReadToEndAsync();
                    tcs.SetResult(false);
                    tcs.SetException(new InvalidOperationException("The process1 did not exit correctly. Error message: " + errorMessage));
                }
                else
                {
                    File.WriteAllText(LogFile, process1.StandardOutput.ReadToEnd());
                    process2.Start();
                }
                process1.Dispose();
            };
    
            process2.Exited += (sender, arguments) =>
            {
                if (process2.ExitCode != 0)
                {
                    string errorMessage = process2.StandardError.ReadToEndAsync();
                    tcs.SetResult(false);
                    tcs.SetException(new InvalidOperationException("The process2 did not exit correctly. Error message: " + errorMessage));
                }
                else
                {
                    File.WriteAllText(LogFile, process2.StandardOutput.ReadToEnd());
                    tcs.SetResult(true);
                }
                process2.Dispose();
            };
    
            process1.Start();
        }
        catch (Exception e)
        {
            Logger.InfoOutputWindow(e.Message);
            tcs.SetResult(false);
            return tcs.Task;
        }
    
        return tcs.Task;
    }
