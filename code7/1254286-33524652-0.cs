    StringBuilder test = new StringBuilder();
    // Not redirected
    ProcessStartInfo psi = new ProcessStartInfo("cmd", "/c echo yes")
    {
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
    };
    Process proc = Process.Start(psi);
    proc.OutputDataReceived += (x, y) => test.Append(y.Data);
    proc.BeginOutputReadLine();
    proc.WaitForExit();
    Console.WriteLine(test.ToString()); // Output: yes
    test.Clear();
    // Redirected
    psi = new ProcessStartInfo("cmd", "/c echo yes > NUL")
    {
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
    };
    proc = Process.Start(psi);
    proc.OutputDataReceived += (x, y) => test.Append(y.Data);
    proc.BeginOutputReadLine();
    proc.WaitForExit();
    Console.WriteLine(test.ToString()); // Blank line
