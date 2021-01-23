    private static string[] processNamesICareAbout =
        new[] { "notepad", "calc", "cmd" };
    private async void process_viewer()
    {
        while (true)
        {
            var processes = Process.GetProcesses()
                .Select(process => process.ProcessName);
            running.SelectionMode = SelectionMode.None;
            stopped.SelectionMode = SelectionMode.None;
            running.DataSource = processNamesICareAbout.Intersect(processes).ToList();
            stopped.DataSource = processNamesICareAbout.Except(processes).ToList();
            await Task.Delay(500);
        }
    }
