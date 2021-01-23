    void p_Exited(object sender, EventArgs e)
    {
        var processes = Process.GetProcessesByName("gta_sa.exe");
        foreach (var process in processes)
            process.Kill();
    }
