    foreach(string var in paths)
    {
    ProcessStartInfo info = new ProcessStartInfo(var);
    info.Verb = "Print";
    info.RedirectStandardError = false;
    info.Arguments = printername;
    info.CreateNoWindow = true;
    info.ErrorDialog = false;
    info.UseShellExecute = true;
    info.WindowStyle = ProcessWindowStyle.Hidden;
    Process cmd = Process.Start(info);
    cmd.WaitForExit();
    }
