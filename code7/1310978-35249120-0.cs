    using System.Diagnostics;
    private static string CaptureCommandPromptOutput(string command, string argument)
    {
        ProcessStartInfo info = new ProcessStartInfo(command, argument);
        info.RedirectStandardOutput = true;
        info.UseShellExecute = false;
        info.CreateNoWindow = true;
        Process p = new Process();
        p.StartInfo = info;
        p.Start();
        return p.StandardOutput.ReadToEnd();
    }  
