    List<PerformanceCounter> instancesList = new List<PerformanceCounter>();
    private void InitializeCounter(string[] instances)
    {
            
        foreach(string name in instances)
        {
            instancesList.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", name));
        }
            
    }
    private void updateCounter()
    {
        foreach(PerformanceCounter counter in instancesList)
        {
            bytes += Math.Round(counter.NextValue() / 1024, 2);
            textBox1.Text = bytes.ToString();
        }
    }
