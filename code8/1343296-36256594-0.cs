    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo = new System.Diagnostics.ProcessStartInfo()
    {
        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
        FileName = "cmd.exe",
        Arguments = "/C netstat -a -n |find \"5816\" |find \"ESTABLISHED\" /c"
    };
    process.Start();
    // Now read the value, parse to int and add 1 (from the original script)
    int output = int.Parse(process.StandardOutput.ReadToEnd()) + 1;
    process.WaitForExit();
