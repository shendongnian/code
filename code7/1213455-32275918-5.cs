    // Call ping directly passing parameters and redirecting output
    var psi = new ProcessStartInfo("ping", "-n 1 8.8.8.8");
    psi.UseShellExecute = false;
    psi.CreateNoWindow = true;
    
    psi.RedirectStandardOutput = true;
    using (var proc = Process.Start(psi))
    {
        using (StreamReader sr = proc.StandardOutput)
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
