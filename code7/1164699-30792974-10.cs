    private async void startProcess()
    {
        try { p.Start(); processIsRunning = true; } catch
        {
            ErrOutput.Append("\r\nError starting cmd process.");
            processIsRunning = false;
        }
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        using (StreamWriter sw = p.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
                do
                {
                    try
                    {
                        string cmd = cmdQueue.Dequeue();
                        if (cmd != null & cmd != "") await sw.WriteLineAsync(cmd);
                    } catch { }
                } while (processIsRunning);
            try { p.WaitForExit(); } catch { ErrOutput.Append("WaitForExit Error.\r\n"); }
        }
    }
