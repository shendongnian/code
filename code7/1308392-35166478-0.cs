    private Timer m_Timer;
    private void Form1_Load(object sender, EventArgs e)
    {
        RefreshProcesses();
        m_Timer = new Timer();
        m_Timer.Interval = 5000;
        m_Timer.Tick += timer_Tick;
        m_Timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        RefreshProcesses();
    }
    private void RefreshProcesses()
    {
        List<string> listbox = new List<string>();
        Process[] processes = Process.GetProcesses();
        foreach (var proc in processes)
        {
            if (!string.IsNullOrEmpty(proc.ProcessName))
                listbox.Add(proc.ProcessName);
        }
        listBox1.DataSource = listbox;
    }
