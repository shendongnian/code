    public int m_PMmonitor() {
        var processes = Process.GetProcessByName("notepad.exe");
        int memory = 0;
        foreach (var process in processes) {
            memory += process.WorkingSet / (1024^2);  // convert bytes to MB
        }
    return memory;
    }
